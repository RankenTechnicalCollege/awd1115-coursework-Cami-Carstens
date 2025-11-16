using Microsoft.AspNetCore.Identity;
using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }
    }
}
