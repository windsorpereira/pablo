using Service;
using Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BomConsorcio.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IPorteService _porteService;

        public ClientesController(IClienteService clienteService,
                                    IPorteService porteService)
        {
            _clienteService = clienteService;
            _porteService = porteService;
        }

        public ActionResult Index()
        {
            return View("Clientes", "_AjaxLayout", _clienteService.ObterTodos());
        }

        [HttpGet]
        public ActionResult Cliente(int? Id)
        {
            var cliente = Id.HasValue ? _clienteService.Obter(Id.Value) : new Cliente();

            cliente.Portes = _porteService.ObterTodos();
            cliente.Portes.Insert(0, new Porte() { Nome = "Selecione" });

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Cliente(Cliente cliente)
        {
            try
            {
                ModelState.Clear();

                cliente.Cnpj = !string.IsNullOrEmpty(cliente.Cnpj) ? Regex.Replace(cliente.Cnpj, "[^0-9]", "") : null;
                
                ValidateModel(cliente);

                cliente = _clienteService.Salvar(cliente);

                cliente.Portes = _porteService.ObterTodos();
                cliente.Portes.Insert(0, new Porte() { Nome = "Selecione" });

                return View("Clientes", "_AjaxLayout", _clienteService.ObterTodos());
            }
            catch (Exception ex)
            {
                var erros = new List<string>();

                ModelState.Values.Where(x => x.Errors.Count() > 0).Select(x => x.Errors.Select(y => y.ErrorMessage).Distinct()).Select(x =>
                {
                    erros = erros.Union(x).ToList();

                    return x;
                }).ToList();

                return new JsonResult() { Data = new { Result = "ERROR", Erros = erros.Distinct() }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public ActionResult Toggle(int Id)
        {
            _clienteService.Toggle(Id);

            return View("Clientes", "_AjaxLayout", _clienteService.ObterTodos());
        }

        public ActionResult Remover(int Id)
        {
            _clienteService.Remover(Id);

            return View("Clientes", "_AjaxLayout", _clienteService.ObterTodos());
        }
    }
}