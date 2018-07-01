using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Core.Base.Model
{
  public  class BaseEntity
    {
        public long OID { get; set; }
        public DateTime? CreateDate { get; set; }
        public BaseEntity()
        {
            this.CreateDate = DateTime.Now;
        }
    }
}
