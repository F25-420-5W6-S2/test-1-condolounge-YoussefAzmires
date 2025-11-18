using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CondoLounge.Data;
using CondoLounge.Data.Entities;

namespace CondoLounge.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public int BuildingId { get; set; }
            public int CondoId { get; set; }
        }

        public List<SelectListItem> Buildings { get; set; }
        public List<SelectListItem> Condos { get; set; }

        public void OnGet()
        {
            Buildings = _db.Buildings
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Name
                })
                .ToList();

            Condos = _db.Condos
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CondoNumber
                })
                .ToList();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = new ApplicationUser
            {
                Email = Input.Email,
                UserName = Input.Email
            };

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Default");

                var condo = await _db.Condos.FindAsync(Input.CondoId);
                condo.UserId = user.Id;
                await _db.SaveChangesAsync();

                return RedirectToPage("RegisterConfirmation");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return Page();
        }
    }
}
