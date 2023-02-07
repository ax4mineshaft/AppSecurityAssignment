using AppSecurityAssignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using AppSecurityAssignment.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.DataProtection;
using System.Reflection.Metadata;

namespace AppSecurityAssignment.Pages.Homepage
{

    [Authorize]
    public class HomepageModel : PageModel
    {
        private readonly AuthDbContext _context;
        public HomepageModel(AuthDbContext context)
        {
            _context = context;
        }

        
        private UserManager<member> userManager { get; }
        private SignInManager<member> signInManager { get; }

        
        public member memberList { get; set; } = new();

        public string creditcard { get; set; }
        
        public void OnGet(string id)
        {
            
            var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
            var protector = dataProtectionProvider.CreateProtector("MySecretKey");
            memberList = _context.Users.FirstOrDefault(x => x.emailAddress.Equals(id));
            creditcard = protector.Unprotect(memberList.creditCardNo);


        }
    }
}
