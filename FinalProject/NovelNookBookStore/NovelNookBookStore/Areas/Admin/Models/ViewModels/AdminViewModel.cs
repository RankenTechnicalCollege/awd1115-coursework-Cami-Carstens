using NovelNookBookStore.Models.DomainModels;


namespace NovelNookBookStore.Areas.Admin.Models
{
    public class AdminHomeViewModel
    {
        public string SearchString { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = new();
        public List<Decor> Decors { get; set; } = new();
    }
}

