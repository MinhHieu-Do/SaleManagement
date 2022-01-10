using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.ViewModels;
namespace WebApp.SaleManagement.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(s => new UserViewModel
            {
                Id = s.Id,
                Email = s.Email,
                Name = s.UserName
            }).ToListAsync();
            return View(users);
        }
        public IActionResult Filter(string searchString)
        {
            ViewData["currentFilter"] = searchString;
            var users = _userManager.Users.Select(s => new UserViewModel
            {
                Id = s.Id,
                Email = s.Email,
                Name = s.UserName
            }).ToList();
            
            return PartialView("_ListUser", users);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();

            var model = new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                UserInRoles = roles.Select(s => new RoleViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Select = userRoles.Exists(x => x == s.Name)
                }).ToList()
            };

            return PartialView("_Details",model);
        }
        public async Task<IActionResult> DeleteBox(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var model = new UserViewModel()
            {
                Id = user.Id,
                Email=user.Email
            };
            return PartialView("_Delete", model);
        }

        [Authorize]
        [HttpPost, ActionName("Details")]
        public async Task<IActionResult> Update(string id, UserViewModel model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            var roles = await _roleManager.Roles.ToListAsync();

            foreach (var role in model.UserInRoles)
            {

                if (role.Select)
                {
                    await _userManager.AddToRoleAsync(user, roles.FirstOrDefault(x => x.Id == role.Id)?.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, roles.FirstOrDefault(x => x.Id == role.Id)?.Name);
                }
            }

            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }
    }
}
