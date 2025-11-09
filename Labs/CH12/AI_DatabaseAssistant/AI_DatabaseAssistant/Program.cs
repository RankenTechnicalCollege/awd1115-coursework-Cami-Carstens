using AI_DatabaseAssistant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using AI_DatabaseAssistant.Plugins;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace AI_DatabaseAssistant;
 

class Program
{
    static async Task Main(string[] args)
    {
        //step 1: Load configuration from appsettings.json(API key and connection string)
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        //step 2: create Database context
        var connectionString = configuration.GetConnectionString("AdventureWorksSales")!;
        var options = new DbContextOptionsBuilder<AdventureWorksContext>()
            .UseSqlServer(connectionString)
            .Options;
        var dbContext = new AdventureWorksContext(options);

        //step 3: Create semantic kernel with OpenAI
        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
            ?? throw new InvalidOperationException("Please set the OPENAI_API_KEY environment variable.");

        var modelId = "gpt-4o";

        //nervous system-conductor of the AI
        var kernel = Kernel.CreateBuilder()
            .AddOpenAIChatCompletion(modelId, apiKey)
            .Build();

        //step 4: add database plugin to the kernel
        kernel.Plugins.AddFromObject(new AdventureWorksQueryPlugin(dbContext));

        //step 5: Chat service for convos
        var chatService = kernel.GetRequiredService<IChatCompletionService>();

        //step 6: Start a conversation loop-Welcoming messages
        Console.WriteLine("Welcome to Adventure Works Database AI Assistant");
        Console.WriteLine("You can ask me questions about the database.");
        Console.WriteLine("Try asking: 'What were the total sales in 2023?'");
        Console.WriteLine("Type 'quit' to exit.");

        //Main chat loop
        while(true)
        {
            Console.Write("You: ");
            var question = Console.ReadLine();
            if (string.IsNullOrEmpty(question) || question.ToLower() == "quit")
                break;

            try
            {
                var answer = await GetAnswer(chatService, kernel, question);
                Console.WriteLine($"AI: {answer}\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"X Error: {ex.Message}\n");

            }
        }
        Console.WriteLine("Goodbye!");

    }
    static async Task<string> GetAnswer(IChatCompletionService chatService, Kernel kernel, string question)
    {
        var chat = new ChatHistory();

        //give AI system instructions
        chat.AddSystemMessage
            (@"You are a helpful AI assistant that can answer questions about the Adventure Works sales database.
        When users ask questions, generate appropriate SQL queries to get the data that is needed.
        Always be friendly and explain your answers clearly.");

        //Add user question
        chat.AddUserMessage(question);


        //Config AI to automatically use our database functions
        var settings = new OpenAIPromptExecutionSettings
        {
            ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions, //call plugins
            Temperature = 0.1 //keep responses focused and accurate
        };

        var result = await chatService.GetChatMessageContentAsync(chat, settings, kernel);
        return result.Content ?? "I'm having trouble understanding your question. Please try rephrasing it. Thank you!";
    }
}