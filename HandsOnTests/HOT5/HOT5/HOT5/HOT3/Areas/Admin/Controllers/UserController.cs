using HOT3.Models;
using HOT3.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HOT3.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
       private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            //get users
            List<User> users = new List<User>();
            //loop through users and get roles
            foreach(User user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }
            UserViewModel model = new UserViewModel { Users = users, Roles = roleManager.Roles };
            return View(model);
        }

        //Add user to admin
        [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {
            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
            if(adminRole == null)
            {
                TempData["Error"] = "Admin role does not exist.";
            }
            else
            {
                User user = await userManager.FindByIdAsync(id);
                await userManager.AddToRoleAsync(user, adminRole.Name);
            }
            return RedirectToAction("Index");
        }

        //Remove user from admin
        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction("Index");

        }

        //Create new role
        [HttpPost] 
        public async Task<IActionResult> CreateRole(string roleName)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
            return RedirectToAction("Index");
        }
        //Add user to role
        [HttpPost]
        public async Task<IActionResult> AddToRole(string id, string role)
        {
            User user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, role);
            return RedirectToAction("Index");
        }
        //Remove user from role
        [HttpPost]
        public async Task<IActionResult> RemoveFromRole(string id, string role)
        {
            User user = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(user, role);
            return RedirectToAction("Index");
        }
        //Delete Role
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        //Delete user
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if(!result.Succeeded)
                {
                    string errorMessage = "";
                    foreach(IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }

                    TempData["message"] = errorMessage;
                }
            }
            return RedirectToAction("Index");
        }

    }
}
