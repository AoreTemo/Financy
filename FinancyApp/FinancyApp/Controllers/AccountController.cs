using DL.Entities;
using FinancyApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FinancyApp.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if(!ModelState.IsValid)
            return View(registerViewModel);

        var user = await _userManager.FindByEmailAsync(registerViewModel.Email);

        if (user != null)
        {
            TempData["Error"] = "This email address is already in use";

            return View(registerViewModel);
        }

        var newUser = new AppUser
        {
            Email = registerViewModel.Email,
            UserName = registerViewModel.UserName,
            Balance = registerViewModel.Balance,
            Categories = new List<Category>(),
            Costs = new List<Cost>(),
            ConfirmPassword = registerViewModel.ConfirmPassword

        };

         await _userManager.CreateAsync(newUser, registerViewModel.Password);

        return RedirectToAction("Index", "Home");

    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
            return View(loginViewModel);
        

        var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

        if (user != null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);

            if (passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["Error"] = "Wrong password";
            return View(loginViewModel);
        }

        TempData["Error"] = "Wrong credentials";

        return View(loginViewModel);
    }
}
