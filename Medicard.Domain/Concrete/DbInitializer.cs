using Medicard.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Concrete
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private MedicardDbContext _context;

        public DbInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, MedicardDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (!_roleManager.RoleExistsAsync(UserRoles.Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(UserRoles.Doctor)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(UserRoles.Patient)).GetAwaiter().GetResult();

                //admin
                _userManager.CreateAsync(new User
                {
                    FirstName = "Andrij",
                    LastName = "Matviiv",
                    Email = "matviivandrij13@gmail.com"
                },"Andrew13mtv@").GetAwaiter().GetResult();
                var appUser = _context.Users.FirstOrDefault(x => x.Email == "matviivandrij13@gmail.com");
                if(appUser != null)
                {
                    _userManager.AddToRoleAsync(appUser, UserRoles.Admin).GetAwaiter();
                }

                //doctor
                _userManager.CreateAsync(new User
                {
                    FirstName = "Marta",
                    LastName = "Dashko",
                    Email = "martadashko@gmail.com"
                }, "Martadashko@").GetAwaiter().GetResult();
                var doctorUser = _context.Users.FirstOrDefault(x => x.Email == "martadashko@gmail.com");
                if (doctorUser != null)
                {
                    _userManager.AddToRoleAsync(appUser, UserRoles.Doctor).GetAwaiter();
                }
            }
        }
    }
}
