namespace NovelNookBookStore.Models.DomainModels
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public Review Review { get; set; }
    }
}
