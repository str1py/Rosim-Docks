using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RosreestDocks.Contexts;
using RosreestDocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RosreestDocks.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministratorController : Controller
    {
        private DataBaseContext db;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public AdministratorController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            db = new DataBaseContext();
            this.roleManager = roleManager;
            this.userManager = userManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        #region Users 
        public async Task<IActionResult> Users()
        {
            //get all users
            var users = userManager.Users.ToList();

            //Create new list cause of add roles
            List<User> appusers = new List<User>();

            foreach (var user in users)
            {
                //get user role
                //: This MySqlConnection is already in use. without TOLIST
                var role = await userManager.GetRolesAsync(user);

                string roleName = "";
                if (role.Count != 0)
                    roleName = role[0];
                else
                    roleName = "User";

                appusers.Add(new User
                {
                    Email = user.Email,
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    RoleName = roleName
                });
            }

            return View(appusers);
        }
        public async Task<ActionResult> ShowUpdateUserModal(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var role = await userManager.GetRolesAsync(user);

            //get all roles to SelectedList
            var roles = CreateRoleList();
            string roleName = "";

            if (role.Count != 0)
            {
                roleName = role[0];
                roles.Where(x => x.Text == roleName).FirstOrDefault().Selected = true;

            }
            else
            {
                roles.Where(x => x.Text == "User").Select(y => { y.Selected = true; return y; });
                roleName = "User";
            }


            User appUser = (new User
            {
                Email = user.Email,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                RoleName = roleName,
                Role = roles
            });

            return PartialView("Modal/UpdateUserModal", appUser);
        }
        public async Task<IActionResult> UpdateUser(User user)
        {
            //WHY ID ISNTO CURRRECT !)o)*#@*($&^&*%&^!*@
            var findedUser = await userManager.FindByIdAsync(user.Id);
       
            findedUser.Email = user.Email;
            findedUser.NormalizedEmail = user.Email.ToUpper();
            findedUser.UserName = user.UserName;
            findedUser.NormalizedUserName = user.UserName.ToUpper();
            findedUser.PhoneNumber = user.PhoneNumber;


            var result = await userManager.UpdateAsync(findedUser);

            //Remove all roles from user
            var list = CreateRoleIEnumerable();
            foreach (var role in list)
            {
                var res = await userManager.RemoveFromRoleAsync(findedUser, role);
            }

            //Add new role
            var rolename = await roleManager.FindByIdAsync(user.RoleName);

            await userManager.AddToRoleAsync(findedUser, rolename.Name);


            return Redirect(Request.Headers["Referer"].ToString());
        }
        #endregion

        #region Roles
        public IActionResult Roles()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            IdentityResult res = await roleManager.CreateAsync(role);

            if (res.Succeeded)
                return Redirect(Request.Headers["Referer"].ToString());
            else
            {
                foreach (IdentityError err in res.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> RemoveRole(string id)
        {
            var item = await roleManager.FindByIdAsync(id);
            IdentityResult res = await roleManager.DeleteAsync(item);

            if (res.Succeeded)
                return Redirect(Request.Headers["Referer"].ToString());
            else
            {
                foreach (IdentityError err in res.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());

        }

        public async Task<IActionResult> EditRole(IdentityRole role)
        {
            IdentityResult res = await roleManager.UpdateAsync(role);
            if (res.Succeeded)
                return Redirect(Request.Headers["Referer"].ToString());
            else
            {
                foreach (IdentityError err in res.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<ActionResult> ShowUpdateRoleModal(string id)
        {
            var item = await roleManager.FindByIdAsync(id);
            if (item != null)
                return PartialView("Modal/UpdateRoleModal", item);
            else return null;
        }

        public ActionResult ShowCreateRoleModal()
        {
            return PartialView("Modal/CreateRoleModal");
        }

        #endregion



        private List<SelectListItem> CreateRoleList()
        {
            var roles = roleManager.Roles;
            var roleList = new List<SelectListItem>();
            foreach (var role in roles)
                roleList.Add(new SelectListItem { Text = role.Name, Value = role.Id.ToString(), Selected = false });

            return roleList;
        }

        private IEnumerable<string> CreateRoleIEnumerable()
        {
            var roles = roleManager.Roles;
            var roleList = new List<string>();
            foreach (var role in roles)
                roleList.Add(role.Name);

            IEnumerable<string> ieList = roleList;
            return ieList;
        }

    }
}
