namespace NovelNookBookStore.Models
{
    public class DiscussionViewModel
    {
        public Discussion NewDiscussion { get; set; } = new Discussion();
        public List<Discussion> Discussions { get; set; } = new List<Discussion>();
    }
}
