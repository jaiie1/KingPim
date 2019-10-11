using Microsoft.AspNetCore.Identity;
using KingPim.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KingPim.Data
{
    public class IdentitySeed : IIdentitySeed
    {
        private const string _admin = "admin";
        private const string _password = "buggeroff";

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentitySeed(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> CreateAdminAccountIfEmpty()
        {
            var admin = await _roleManager.RoleExistsAsync("Administrator");
            if (!admin)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                await _roleManager.CreateAsync(role);
            }

            if (!_context.Users.Any(u => u.UserName == _admin))
            {
                var user = new IdentityUser
                {
                    UserName = _admin,
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, _password);
                var test = await _userManager.AddToRoleAsync(user, "Administrator");
            }

            var publisher = await _roleManager.RoleExistsAsync("Publisher");
            if (!publisher)
            {
                var role = new IdentityRole
                {
                    Name = "Publisher"
                };
                await _roleManager.CreateAsync(role);
            }
            var editor = await _roleManager.RoleExistsAsync("Editor");
            if (!editor)
            {
                var role = new IdentityRole
                {
                    Name = "Editor"
                };
                await _roleManager.CreateAsync(role);
            }
            return true;
        }
    }
}