using _27_FrontToBackSql.Models;
using _27_FrontToBackSql.Utilities.Enums;
using _27_FrontToBackSql.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace _27_FrontToBackSql.Controllers;

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
   public async Task<IActionResult> Register()
   {
      return View();
   }

   [HttpPost]
   public async Task<IActionResult> Register(RegisterVM registerVM)
   {
      if (!ModelState.IsValid) return View();

      AppUser appUser = new()
      {
         Name = registerVM.Name,
         Surname = registerVM.Surname,
         UserName = registerVM.Username,
         Email = registerVM.Email,
      };
      
      IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

      if (!result.Succeeded)
      {
         foreach (IdentityError error in result.Errors)
         {
            ModelState.AddModelError(string.Empty, error.Description);
         }

         return View(registerVM);
      }
      
      await _userManager.AddToRoleAsync(appUser, UserRole.Member.ToString());
      
      return RedirectToAction(nameof(HomeController.Index),  "Home");
   }

   public async Task<IActionResult> Login()
   {
      return View();
   }

   [HttpPost]
   public async Task<IActionResult> Login(LoginVM loginVM)
   {
      if (!ModelState.IsValid) return View();
      
      AppUser? appUser = await _userManager.Users
         .FirstOrDefaultAsync(u=>u.UserName == loginVM.UsernameOrEmail || u.Email == loginVM.UsernameOrEmail);

      if (appUser == null)
      {
         ModelState.AddModelError(string.Empty, "Username or Email is incorrect.");
      }
      
      SignInResult result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.IsPersitent, true);

      if (result.IsLockedOut)
      {
         ModelState.AddModelError(string.Empty, "Account is locked. Please try later!");
         return View();
      }

      if (!result.Succeeded)
      {
         ModelState.AddModelError(string.Empty, "Username or Email is incorrect.");
         return View();
      }
      
      return RedirectToAction(nameof(HomeController.Index),  "Home");
   }

   public async Task<IActionResult> Logout()
   {
      await _signInManager.SignOutAsync();
      return RedirectToAction(nameof(HomeController.Index), "Home");
   }

   public async Task<IActionResult> CreateRoles()
   {
      foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
      {
         await _roleManager.CreateAsync(new IdentityRole {Name = role.ToString()});
      }
      return RedirectToAction(nameof(HomeController.Index), "Home");
   }
}