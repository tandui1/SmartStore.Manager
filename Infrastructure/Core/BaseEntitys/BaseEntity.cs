using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.BaseEntity
{
  public  class BaseEntity
    {
        public Guid OID { get; set; }
        public BaseEntity()
        {
            OID = Guid.NewGuid();
        }
    }
}
