using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppSecurityAssignment.Models;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace AppSecurityAssignment.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public login LModel { get; set; }

        private readonly SignInManager<member> signInManager;
        public LoginModel(SignInManager<member> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try { 
            if (ModelState.IsValid)
            {
                
                var _emailAddress = HttpUtility.HtmlEncode(LModel.loginEmail);
               

                var _password = HttpUtility.HtmlEncode(LModel.loginPassword);
                
                var identityResult = await signInManager.PasswordSignInAsync(_emailAddress,_password,LModel.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    return RedirectToPage("/Homepage/Homepage", new { id = _emailAddress } );
                }
                ModelState.AddModelError("", "Email Address or Password incorrect");
            }
            return Page();
        }

            
            
            catch(Exception)
            {
                return RedirectToPage("/Errorpage");
    }


}
    }
}
