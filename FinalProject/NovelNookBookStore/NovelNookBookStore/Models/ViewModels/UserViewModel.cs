using Microsoft.AspNetCore.Identity;
using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Models.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; } = null!;
        public IEnumerable<IdentityRole> Roles { get; set; } = null!;
    }
}
