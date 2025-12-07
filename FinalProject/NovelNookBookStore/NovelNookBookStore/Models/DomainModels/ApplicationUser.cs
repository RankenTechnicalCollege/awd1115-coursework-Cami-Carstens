using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelNookBookStore.Models.DomainModels
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }

        public ICollection<Review>? Reviews { get; set; } = new List<Review>();


        [NotMapped]
        public IList<string> RoleNames { get; set; } = null!;
    }
}
