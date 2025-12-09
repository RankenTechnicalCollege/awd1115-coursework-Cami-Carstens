using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Models.ViewModels
{
    public class HomeViewModel
    {
        public Quote QuoteOfTheDay { get; set; } = new Quote();
    }
}
