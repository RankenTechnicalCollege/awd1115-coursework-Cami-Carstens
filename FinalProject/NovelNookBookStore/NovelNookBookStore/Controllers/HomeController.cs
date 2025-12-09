using Microsoft.AspNetCore.Mvc;
using NovelNookBookStore.Models;
using NovelNookBookStore.Models.DomainModels;
using NovelNookBookStore.Models.ViewModels;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;



namespace NovelNookBookStore.Controllers
{
    //CH16add API call to get book quote for home page
    public class HomeController : Controller
    {
       
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var quote = await GetBookQuoteAsync();

            var model = new HomeViewModel
            {
                QuoteOfTheDay = quote
            };
            return View(model);
        }
        private async Task<Quote?> GetBookQuoteAsync()
        {
            try
            {
                var client = _clientFactory.CreateClient("quotable");

                var response = await client.GetStringAsync("https://api.quotable.io/random?tags=famous-quotes");
                if (string.IsNullOrEmpty("Empty response"))
                {
                    throw new Exception("No responses from quote API");
                }
                ;
                var quote = JsonSerializer.Deserialize<Quote>(response);
                return quote;
            }
            catch
            {

                return new Quote
                {
                    Content = "Reading is an exercise in empathy; an exercise in walking in someone else's shoes for a while.",
                    Author = "Malorie Blackman"
                };
            }
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
