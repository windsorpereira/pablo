using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.ViewModel;
using Data.Repositories;
using Data;
using System.Text.RegularExpressions;

namespace Service.Impl
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [UnitOfWork]
        public Cliente Obter(int Id)
        {
            return new Cliente(_clienteRepository.Get(Id));
        }

        public IList<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos().Select(x =>
            {
                return new Cliente(x);
            }).ToList();
        }

        [UnitOfWork]
        public Cliente Salvar(Cliente cliente)
        {
            var _cliente = new Data.Model.Cliente()
            {
                Id = cliente.Id,
                Ativo = cliente.Ativo,
                Cnpj = !String.IsNullOrEmpty(cliente.Cnpj) ? long.Parse(Regex.Replace(cliente.Cnpj, "[^0-9]", "")) : (long?) null,
                NomeFantasia = cliente.NomeFantasia,
                PorteId = cliente.PorteId,
                RazaoSocial = cliente.RazaoSocial
            };

            if (cliente.Id == 0)
            {
                _clienteRepository.Insert(_cliente);
            }
            else
            {
                _clienteRepository.Update(_cliente);
            }

            return new Cliente(_cliente);
        }

        public void Toggle(int Id)
        {
            var cliente = _clienteRepository.Get(Id);

            cliente.Ativo = !cliente.Ativo;

            _clienteRepository.Update(cliente);
        }

        public void Remover(int Id)
        {
            _clienteRepository.Delete(Id);
        }
    }
}
