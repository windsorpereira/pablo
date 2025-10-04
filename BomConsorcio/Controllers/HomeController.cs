using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.ViewModel;

namespace BomConsorcio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClienteService _clienteService;

        public HomeController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public ActionResult Dashboard(bool? Ajax)
        {
            var clientes = _clienteService.ObterTodos();

            var model = new Dashboard(clientes);

            if (Ajax.HasValue && Ajax.Value)
            {
                return View("Dashboard", "_AjaxLayout", model);
            }
            else
            {
                return View(model);
            }
        }
    }
}