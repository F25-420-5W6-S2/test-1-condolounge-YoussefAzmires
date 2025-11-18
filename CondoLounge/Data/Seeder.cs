using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace CondoLounge.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public Seeder(ApplicationDbContext context,
                IWebHostEnvironment hosting,
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole<int>> roleManager)
        {
            _db = context;
            _hosting = hosting;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            _db.Database.EnsureCreated();

            // ----------------------------
            // Create Roles
            // ----------------------------
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Default"));
            }

            // ----------------------------
            // Create Initial Building + Condo
            // ----------------------------
            Building initialBuilding = null;

            if (!_db.Buildings.Any())
            {
                initialBuilding = new Building()
                {
                    Name = "Main Building"
                };

                await _db.Buildings.AddAsync(initialBuilding);
            }
            else
            {
                initialBuilding = _db.Buildings.First();
            }

            Condo initialCondo = null;

            if (!_db.Condos.Any())
            {
                initialCondo = new Condo()
                {
                    CondoNumber = "101",
                    Address = "123 Example Street",
                    Building = initialBuilding
                };

                await _db.Condos.AddAsync(initialCondo);
            }
            else
            {
                initialCondo = _db.Condos.First();
            }

            // ----------------------------
            // Create Admin User
            // ----------------------------
            if (!_userManager.Users.Any())
            {
                var admin = new ApplicationUser()
                {
                    UserName = "admin@email.com",
                    Email = "admin@email.com"
                };

                var result = await _userManager.CreateAsync(admin, "Admin123!");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, "Admin");

                    initialCondo.User = admin;
                }

                var user = new ApplicationUser()
                {
                    UserName = "user@email.com",
                    Email = "user@email.com"
                };

                var userResult = await _userManager.CreateAsync(user, "User123!");

                if (userResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Default");
                }
            }

            await _db.SaveChangesAsync();
        }
    }
}
