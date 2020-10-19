using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pessoa_crud.Models;
using pessoa_crud.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.Controllers {
    public class ContaController : Controller {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public ContaController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) {
            _userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar() {
            ViewBag.ErrorMessage = null;
            return View(new ContaRegistrarViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(ContaRegistrarViewModel user) {
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
            Console.WriteLine("asdasdasd");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Pessoa");
        }
    }
}

/**
 try {
                if (string.IsNullOrEmpty(user.Email))
                   throw new Exception("The username cannot be empty!");
                
                if (string.IsNullOrEmpty(user.Senha))
                    throw new Exception("The password cannot be empty!");

                if (user.Senha != user.ConfirmarSenha)
                    throw new Exception("The Passwords do not match!");

                var theUser = new ApplicationUser() {
                    UserName = user.Email,
                    Email = user.Email
                };

                var result = await _userManager.CreateAsync(theUser, user.Senha);
                Console.WriteLine(result.Succeeded);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(theUser, isPersistent: false);
                    Console.WriteLine("AAAAAAAAAAAAAA");
                    return RedirectToAction("Index");
                } else {
                    Console.WriteLine("BBBBBBBBBBBB");
                    return View(user);
                }

                
                // 
            }
            catch (Exception ex) {
                return View(user);
            }
        
        
 */