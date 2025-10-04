using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Data.Repositories
{
    public interface IClienteRepository : IRepository<Cliente, int>
    {
        IList<Cliente> ObterTodos();
    }
}
