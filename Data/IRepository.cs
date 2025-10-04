using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository
    {

    }

    public interface IRepository<T, TIdentity> : IRepository where T : BaseModel<TIdentity>
    {
        IQueryable<T> GetAll();
        T Get(TIdentity key);
        void Insert(T entity);
        void Update(T entity);
        void Delete(TIdentity id);
    }
}
