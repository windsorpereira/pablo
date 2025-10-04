using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BomConsorcio.Controllers
{
    public class PortesController : Controller
    {
        private readonly IPorteService _porteService;

        public PortesController(IPorteService porteService)
        {
            _porteService = porteService;
        }

        public ActionResult Index()
        {
            return View("Portes", "_AjaxLayout", _porteService.ObterTodos());
        }
    }
}