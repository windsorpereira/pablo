using Data.Model;
using Data.NHibernate;
using NHibernate;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Impl
{
    public class ClienteRepository : NhRepositoryBase<Cliente, int>, IClienteRepository
    {   
        IList<Cliente> IClienteRepository.ObterTodos()
        {
            Porte por = null;

            List<Cliente> clientes = Session.QueryOver<Cliente>()
                .JoinAlias(x => x.Porte, () => por, JoinType.LeftOuterJoin)
                .List().ToList<Cliente>();

            return clientes;
        }
    }
}
