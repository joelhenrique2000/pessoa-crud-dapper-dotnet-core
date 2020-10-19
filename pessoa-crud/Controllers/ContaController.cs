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

        public ContaController(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
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
            Console.WriteLine("OI");
            try {
                //if (string.IsNullOrEmpty(user.Username))
                //   throw new Exception("The username cannot be empty!");
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Senha);
                Console.WriteLine(user.ConfirmarSenha);
                
                if (string.IsNullOrEmpty(user.Senha))
                    throw new Exception("The password cannot be empty!");

                if (user.Senha != user.ConfirmarSenha)
                    throw new Exception("The Passwords do not match!");

                var theUser = new ApplicationUser() {
                    UserName = user.Email,
                    Email = user.Email
                };

                await _userManager.CreateAsync(theUser, user.Senha);

                return View(new ContaRegistrarViewModel());
            }
            catch (Exception ex) {
                return View(user);
            }
        }

    }
}
