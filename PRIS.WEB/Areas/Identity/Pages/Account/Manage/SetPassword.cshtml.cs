﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PRIS.WEB.Areas.Identity.Pages.Account.Manage
{
    public class SetPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public SetPasswordModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "{0} turi būti ne trumpesnis nei {2} simboliai ir ne ilgesnis nei {1} simbolių.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Naujas slaptažodis")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Patvirtinti naują slaptažodį")]
            [Compare("NewPassword", ErrorMessage = "Slaptažodžiai nesutampa.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Nepavyksta įkelti vartotojo su ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);

            if (hasPassword)
            {
                return RedirectToPage("./ChangePassword");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Nepavyksta įkelti vartotojo su ID '{_userManager.GetUserId(User)}'.");
            }

            var addPasswordResult = await _userManager.AddPasswordAsync(user, Input.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                foreach (var error in addPasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);


            StatusMessage = "Jūsų slaptažodis išsaugotas sėkmingai.";

            return RedirectToPage();
        }
    }
}
