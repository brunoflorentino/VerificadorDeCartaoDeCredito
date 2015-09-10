using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerificadorDeCartaoDeCredito.Business;
using VerificadorDeCartaoDeCredito.Models;

namespace VerificadorDeCartaoDeCredito.Controllers
{
    public class VerificadorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CartaoCredito cartaoCredito)
        {
            ViewBag.Resultado = ValidarCartaoCreditoBusiness.ValidarCartaoCredito(cartaoCredito);
            return View();
        }
    }
}