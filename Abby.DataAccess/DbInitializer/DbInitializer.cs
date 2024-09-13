using Abby.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Abby.Utility;
using Abby.Models;
using Microsoft.Extensions.Logging;

namespace Abby.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(AppDbContext context,
                            UserManager<IdentityUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            ILogger<DbInitializer> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public void Initialize()
        {
            // Add Migrations
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Log the exception.
                _logger.LogError(ex, "An error occurred while applying migrations.");
            }

            // Seed the roles.
            try
            {
                if (!_roleManager.RoleExistsAsync(SD.ManagerRole).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.ManagerRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.KitchenRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.FrontDeskRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.CustomerRole)).GetAwaiter().GetResult();

                    _userManager.CreateAsync(new ApplicationUser()
                    {
                        UserName = "Admin@gmail.com",
                        Email = "Admin@gmail.com",
                        EmailConfirmed = true,
                        FirstName = "Admin",
                        LastName = "Admin"
                    }, password: "Admin123456q!").GetAwaiter().GetResult();

                    ApplicationUser user = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "Admin@gmail.com");
                    if (user != null)
                    {
                        _userManager.AddToRoleAsync(user, SD.ManagerRole).GetAwaiter().GetResult();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception.
                _logger.LogError(ex, "An error occurred while seeding roles and users.");
            }
        }
    }
}
