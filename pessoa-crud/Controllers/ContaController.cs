using Microsoft.AspNetCore.Mvc;
using pessoa_crud.Models;
using pessoa_crud.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.Controllers {
    public class ContaController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Registrar() {
            ViewBag.ErrorMessage = null;
            return View(new ContaRegistrarViewModel());
        }
    }
}
