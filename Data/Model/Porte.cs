using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Porte : BaseModel<int>
    {
        public Porte()
        {
            Clientes = new HashSet<Cliente>();
        }

        public virtual string Nome { get; set; }

        public virtual ISet<Cliente> Clientes { get; set; }
    }
}
