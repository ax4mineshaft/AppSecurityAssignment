using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppSecurityAssignment.Models;
using Microsoft.Win32;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using System.Text.RegularExpressions;

namespace AppSecurityAssignment.Pages.Registration
{
    public class registerFormModel : PageModel
    {


        [BindProperty]
        public member NewMember { get; set; }
        [BindProperty]
        public IFormFile? Image { get; set;}
        private UserManager<member> userManager { get; }
        private SignInManager<member> signInManager { get; }
        private IWebHostEnvironment _environment;

        public registerFormModel(UserManager<member> userManager,

        SignInManager<member> signInManager, IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _environment = environment;
        }
        public void OnGet()
        {

            

        }


        public async Task<IActionResult> OnPostAsync()
        {
            try {
                if (Image != null)
                {
                    /* string extension = System.IO.Path.GetExtension(Image.FileName);
                     if (extension == ".jpg")*/


                    if (ModelState.IsValid)
                    {
                        var _fullname = HttpUtility.HtmlEncode(NewMember.fullName);
                        var _emailAddress = HttpUtility.HtmlEncode(NewMember.emailAddress);
                        var _gender = HttpUtility.HtmlEncode(NewMember.gender);
                        var _phoneNo = HttpUtility.HtmlEncode(NewMember.phoneNo);
                        var _creditCardNo = HttpUtility.HtmlEncode(NewMember.creditCardNo);
                        var _deliveryAddress = HttpUtility.HtmlEncode(NewMember.deliveryAddress);
                        var _photo = HttpUtility.HtmlEncode(NewMember.photo);
                        var _aboutMe = HttpUtility.HtmlEncode(NewMember.aboutMe);

                        var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
                        var protector = dataProtectionProvider.CreateProtector("MySecretKey");
                        member user = new member()
                        {
                            fullName = _fullname,
                            UserName = _emailAddress,

                            emailAddress = _emailAddress,
                            gender = _gender,
                            phoneNo = _phoneNo,
                            creditCardNo = protector.Protect(_creditCardNo),

                            deliveryAddress = _deliveryAddress,
                            photo = _photo,
                            aboutMe = _aboutMe
                        };

                        var uploadsFolder = "uploads";
                        var imageFile = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                        var imagePath = Path.Combine(_environment.ContentRootPath, "wwwroot", uploadsFolder, imageFile);
                        using var fileStream = new FileStream(imagePath, FileMode.Create);
                        await Image.CopyToAsync(fileStream);
                        user.photo = string.Format("/{0}/{1}", uploadsFolder, imageFile);

                        var result = await userManager.CreateAsync(user, NewMember.password);
                        if (result.Succeeded)
                        {

                            return RedirectToPage("/Account/Login");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }



                return Page();
            }

            
            
            catch(Exception)
            {
                return RedirectToPage("/Errorpage");
            }

}


        /*private int checkPassword(string password)
        {
            int score = 0;
            if (password.Length < 8)
            {
                return 1;
            }
            else {
                score++;
            }
            if (Regex.IsMatch(password, "[a-z]"))
            {
                score++;
            }
            return score;
        }*/

    } }
