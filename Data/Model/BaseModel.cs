using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class BaseModel<TIdentity> : IBaseModel<TIdentity>
    {
        public virtual TIdentity Id { get; set; }
    }
}
