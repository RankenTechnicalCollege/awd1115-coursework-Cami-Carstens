using System.Text.Json.Serialization;

namespace NovelNookBookStore.Models.DomainModels
{
    public class Quote
    {
        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("author")]
        public string? Author { get; set; }
    }
}
