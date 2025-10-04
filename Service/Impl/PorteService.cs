using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.ViewModel;
using Data.Repositories;
using Data;

namespace Service.Impl
{
    public class PorteService : IPorteService
    {
        private readonly IPorteRepository _porteRepository;

        public PorteService(IPorteRepository porteRepository)
        {
            _porteRepository = porteRepository;
        }

        public IList<Porte> ObterTodos()
        {
            return _porteRepository.ObterTodosSqlCommand().Select(x =>
            {
                return new Porte(x);
            }).ToList();
        }
    }
}
