using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CondoLounge.Data.Entities;
using CondoLounge.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace CondoLounge.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public List<SelectListItem> Buildings { get; set; }
        public List<SelectListItem> Condos { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }

            [Required]
            public int BuildingId { get; set; }

            [Required]
            public int CondoId { get; set; }
        }

        public void PopulateDropdowns()
        {
            Buildings = _db.Buildings.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            }).ToList();

            Condos = _db.Condos.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CondoNumber
            }).ToList();
        }

        public void OnGet()
        {
            PopulateDropdowns();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            PopulateDropdowns();

            if (!ModelState.IsValid)
                return Page();

            var user = new ApplicationUser
            {
                UserName = Input.Email,
                Email = Input.Email
            };

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                // Assign default role
                await _userManager.AddToRoleAsync(user, "Default");

                // TODO: Save user Building and Condo association here if your model supports it

                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect("~/");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }
    }
}
