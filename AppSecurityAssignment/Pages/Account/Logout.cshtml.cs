using AppSecurityAssignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppSecurityAssignment.Pages.Login
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<member> signInManager;
        public LogoutModel(SignInManager<member> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet() { }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/Account/Login");
        }
        public async Task<IActionResult> OnPostDontLogoutAsync()
        {
            return RedirectToPage("/Index");
        }
    }
}
