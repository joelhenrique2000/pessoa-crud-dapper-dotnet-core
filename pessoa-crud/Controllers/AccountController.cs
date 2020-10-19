using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pessoa_crud.Models;
using pessoa_crud.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.Controllers {
    public class AccountController : Controller {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) {
            _userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl) {
           // Console.WriteLine(returnUrl);
           // if (Url.IsLocalUrl(returnUrl)) {
           //     return Redirect(returnUrl);
           // }
           // else {
                return View(new AccountLoginViewModel());
            //}
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model) {
            if (ModelState.IsValid) {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Senha, false, false);
                if (result.Succeeded) {
                    return RedirectToAction("Index", "Pessoa");
                }
                ModelState.AddModelError(string.Empty, "Login Inválido");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register() {
            ViewBag.ErrorMessage = null;
            return View(new ContaRegistrarViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(ContaRegistrarViewModel user) {
            if (ModelState.IsValid) {
                var usuario = new ApplicationUser() {
                    UserName = user.Email,
                    Email = user.Email,
                };

                var result = await _userManager.CreateAsync(usuario, user.Senha);

                if (result.Succeeded) {
                    await _signInManager.SignInAsync(usuario, false);

                    return RedirectToAction("Index", "Pessoa");
                    // return View("CadastradoSucesso", viewModel);
                }

                foreach (var error in result.Errors) {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return View(user);

        }

        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Pessoa");
        }
    }
}
