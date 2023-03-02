using ForumAdminPanel.Data;
using ForumAdminPanel.Models;
using ForumAdminPanel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumAdminPanel.Controllers
{
    public class AccountController : Controller
    {   
        private readonly UserManager<AdminAppUser> _userManager;
        private readonly SignInManager<AdminAppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<AdminAppUser> userManager, SignInManager<AdminAppUser> signInManager, ApplicationDbContext context)
        {
            _context = context; 
            _userManager = userManager; 
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) 
            { 
                return View(loginViewModel);    
            }

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if(User != null)
            {
                bool checkPass = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                
                if(checkPass)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if(result.Succeeded) 
                    { 
                        return  RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Wrong credentials";
                return View(loginViewModel);
            }
            TempData["Erorr"] = "User not found";
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public  async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);

            if(user!=null)
            {
                TempData["Error"] = "This email address is alredy in use";
                return View(registerViewModel);
            }

            var newUser = new AdminAppUser 
            { 
                Email = registerViewModel.Email, 
                UserName= registerViewModel.Email,
            }; 

            var newUserResponse = await _userManager.CreateAsync(newUser,registerViewModel.Password);

            //PasswordHasher requred  number and symbol included
            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.Admin);
            }
            return View("SuccessRegister");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        { 
            await   _signInManager.SignOutAsync();
            return RedirectToAction("Home","Index");
        }
    }
}
