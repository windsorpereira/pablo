using Data.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.NHibernate.Mapping
{
    public class PorteMap : ClassMap<Porte>
    {
        public PorteMap()
        {
            Id(c => c.Id).Column("id").GeneratedBy.Identity();
            Map(c => c.Nome).Column("nome");

            HasMany<Cliente>(x => x.Clientes).KeyColumn("PORTE_id")
            .Not.KeyUpdate()
            .Cascade.None();
        }
    }
}
