using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using OpenAI.Assistants;
using OpenAI.Batch;



//populate values 
var modelId = "gpt-4o-mini";


var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? throw new InvalidOperationException();

//create a kernel
var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId, apiKey);

//build the kernel
Kernel kernel = builder.Build();

//enable chat
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

//add a plugin <LightsPlugin> class
kernel.Plugins.AddFromType<LightsPlugin>("Lights");

//enable planning
OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
};

var history = new ChatHistory();
string? userInput; 
do
{
    //collect user input
    Console.WriteLine("User > ");
    userInput = Console.ReadLine();

    //add user input
    history.AddUserMessage(userInput);

    //get Ai response
    var result = await chatCompletionService.GetChatMessageContentAsync(
      history,
      executionSettings: openAIPromptExecutionSettings,
      kernel: kernel);

    //print results
    Console.WriteLine("Assistant > " + result);

    //add the message from the agent to the chat history
    history.AddMessage(result.Role, result.Content ?? string.Empty);
}
while (userInput is not null);