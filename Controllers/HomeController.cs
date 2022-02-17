using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeSec.Models;
using CodeSec.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeSec.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private ICodeSecRepository repository;

        public HomeController(ICodeSecRepository repo, UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            repository = repo;
            userManager = userMgr;
            signInManager = signInMgr;
        }

    //shows view index - Razor views are used for checklist: 7
    [AllowAnonymous]
    public ViewResult Index()
        {
            var mySickNote = HttpContext.Session.GetJson<SickNote>("NewSickNote");
            if (mySickNote == null)
            {
                return View();
            }
            else
            {
                return View(mySickNote);
            }
        }
        public ViewResult ReceiveForm()
        {
            return View();
        }

    //shows login view 
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken] //connected to taghelper to protect app login from cross site request forgery via hidden field where a value is added that later needs validation in our action (checklist: 7)
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.UserName); //if the username entered is found, the object is added to identityuser
                if (user != null)
                {
                    await signInManager.SignOutAsync(); //if user is already logged in, it gets signed out
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded) //checks password
                    {
                        if (await userManager.IsInRoleAsync(user, "ExecutiveEmployee"))
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/ExecutiveEmployee/StartExecutiveEmployee"); //cookie is created
                        }else if(await userManager.IsInRoleAsync(user, "RegularEmployee"))
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/RegularEmployee/StartRegularEmployee");
                        }
                        else if(await userManager.IsInRoleAsync(user, "Admin"))
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/Admin/StartAdmin");
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Felaktigt användarnamn eller lösenord");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync(); //if user is already logged in, it gets signed out
            return Redirect(returnUrl);
        }

        [AllowAnonymous]
        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}
