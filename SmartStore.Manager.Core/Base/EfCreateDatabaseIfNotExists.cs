using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Core.Base
{
  public  class EfCreateDatabaseIfNotExists<TContext> : CreateDatabaseIfNotExists<TContext> where TContext : DbContext
    {
        protected override void Seed(TContext context)
        {
            base.Seed(context);
        }
    }
}
