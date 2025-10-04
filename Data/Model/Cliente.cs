using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Cliente : BaseModel<int>
    {   
        public virtual string NomeFantasia { get; set; }
        public virtual int PorteId { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual long? Cnpj { get; set; }
        public virtual bool Ativo{ get; set; }

        public virtual Porte Porte { get; set; }
    }
}
