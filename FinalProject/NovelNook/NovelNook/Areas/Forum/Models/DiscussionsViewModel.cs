namespace NovelNook.Areas.Forum.Models
{
    public class DiscussionsViewModel
    {
        public Discussion NewDiscussion { get; set; } = new Discussion();
        public List<Discussion> Discussions { get; set; } = new List<Discussion>();
    }
}
