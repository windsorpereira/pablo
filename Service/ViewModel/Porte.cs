using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel
{
    public class Porte
    {
        public Porte()
        {
            Clientes = new List<Cliente>();
        }

        public Porte(Data.Model.Porte porte)
        {
            Id = porte.Id;
            Nome = porte.Nome;

            Clientes = porte.Clientes.Select(x => new Cliente(x)).ToList();
        }

        public virtual int? Id { get; set; }
        public virtual string Nome { get; set; }

        public virtual IList<Cliente> Clientes { get; set; }
    }
}
