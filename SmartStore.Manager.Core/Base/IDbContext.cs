using SmartStore.Manager.Core.Base.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Core.Base
{
  public  interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        void SetDatabaseInitializer();

        System.Data.Entity.Database GetDateBase();
        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int Execute(string sql, params object[] parameters);

        IList<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters);

        void Dispose();
    }
}
