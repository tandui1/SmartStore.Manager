using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Core.Uow
{
  public  interface IUnitOfWork: IDisposable
    {
        void Begin(UnitOfWorkOptions options);


        void Commit();

        void Release(IDbContext dbContext);
    }
}
