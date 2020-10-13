using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pessoa_crud.Business;
using pessoa_crud.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud.Controllers
{
    public class PessoaController : Controller
    {
        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            PessoaBusiness business = new PessoaBusiness();

            return View(business.GetAll());
        }

        [HttpGet]
        public ViewResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Criar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                PessoaBusiness business = new PessoaBusiness();
                business.Create(pessoa);

                return View("CadastradoSucesso", pessoa);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Remover(int id)
        {
            PessoaBusiness business = new PessoaBusiness();
            business.Remove(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar (int id)
        {
            PessoaBusiness business = new PessoaBusiness();
            Pessoa pessoa = business.GetById(id);

            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Editar(Pessoa pessoa)
        {
            PessoaBusiness business = new PessoaBusiness();

            if (ModelState.IsValid)
            {
                business.Update(pessoa);
            }
            else
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
 