using System.Collections.Generic;
using Microsoft.Identity.Client;
using NovelNook.Models;

namespace NovelNook.Models
{
    public class BookShelfViewModel
    {
        public IEnumerable<BookShelfEntry> BookShelfEntries { get; set; } 
        public List<BookShelfEntry> bookEntries { get; set; }

        public IEnumerable<BookRecommendation> BookRecommendations { get; set; }
    }
}
