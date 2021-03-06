﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pessoa_crud.Business;
using pessoa_crud.Models;
using pessoa_crud.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.Controllers
{
    public class AccountController : Controller
    {

        private AccountBusiness _business;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _business = new AccountBusiness(userManager, signInManager);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new AccountLoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _business.Login(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Pessoa");
                }
                ModelState.AddModelError(string.Empty, "Login Inválido");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.ErrorMessage = null;
            return View(new ContaRegistrarViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(ContaRegistrarViewModel user)
        {
            if (ModelState.IsValid)
            {
                var usuario = new ApplicationUser()
                {
                    UserName = user.Email,
                    Email = user.Email,
                };

                var result = await _business.Register(usuario, user.Senha);

                if (result.Succeeded)
                {
                    await _business.SignIn(usuario);
                    return RedirectToAction("Index", "Pessoa");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return View(user);

        }

        public async Task<IActionResult> Logout()
        {
            await _business.SignOut();
            return RedirectToAction("Index", "Pessoa");
        }
    }
}
