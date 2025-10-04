using Data.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.NHibernate.Mapping
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Id(c => c.Id).Column("id").GeneratedBy.Identity();
            Map(c => c.NomeFantasia).Column("nome_fantasia");
            Map(c => c.PorteId).Column("PORTE_id");
            Map(c => c.Cnpj).Column("cnpj").Nullable();
            Map(c => c.RazaoSocial).Column("razao_social").Nullable();
            Map(c => c.Ativo);

            References(x => x.Porte)
            .Class<Porte>()
            .Columns("PORTE_id")
            .Not.Update()
            .Not.Insert();
        }
    }
}
