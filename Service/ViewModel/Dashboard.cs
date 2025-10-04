using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel
{
    public class Dashboard
    {
        public Dashboard(IList<Cliente> clientes)
        {
            DadosPortes = new List<PorteData>()
            {
                new PorteData() { Porte = "Pequeno", Quantidade = clientes.Count(x => x.PorteId == 1) },
                new PorteData() { Porte = "Médio", Quantidade = clientes.Count(x => x.PorteId == 2) },
                new PorteData() { Porte = "Grande", Quantidade = clientes.Count(x => x.PorteId == 3) }
            };

            TotalClientes = clientes.Count();
            ClientesInativos = clientes.Count(x => !x.Ativo);
            ClientesGrandePorte = clientes.Count(x => x.PorteId == 3);
        }

        public virtual int TotalClientes { get; set; }
        public virtual int ClientesInativos { get; set; }
        public virtual int ClientesGrandePorte { get; set; }

        public virtual double ProporcaoInativos { get { return (double)ClientesInativos / (double)TotalClientes; } }


        public virtual IList<PorteData> DadosPortes { get; set; }
    }

    public class PorteData
    {
        public virtual string Porte { get; set; }
        public virtual int Quantidade { get; set; }
    }
}
