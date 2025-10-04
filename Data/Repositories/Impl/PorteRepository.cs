using Data.Model;
using Data.NHibernate;
using NHibernate;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Impl
{
    public class PorteRepository : NhRepositoryBase<Porte, int>, IPorteRepository
    {
        public IList<Porte> ObterTodosSqlCommand()
        {
            var portes = new List<Porte>();

            var query = @" SELECT * FROM PORTE";

            using (SqlConnection connection = new SqlConnection(Session.Connection.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        portes.Add(new Porte() { Id = (int)reader[0], Nome = reader[1].ToString() });
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return portes;
        }

        IList<Porte> IPorteRepository.ObterTodos()
        {
            Cliente cli = null;

            List<Porte> portes = Session.QueryOver<Porte>()
                .JoinAlias(x => x.Clientes, () => cli, JoinType.LeftOuterJoin)
                .List().Distinct().ToList<Porte>();

            return portes;
        }
    }
}
