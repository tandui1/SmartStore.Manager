using SmartStore.Manager.Core.Base.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Core.Base
{
    public class SmartStoreDBContext : DbContext,IDbContext
    {
        public SmartStoreDBContext(string conStr)
           : base(conStr)
        {

            Database.SetInitializer<SmartStoreDBContext>(null); //关闭策略，采取主动控制的方式
                                                        //  this.Database.CommandTimeout = 10;
                                                        //  this.Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
     .Where(type => !String.IsNullOrEmpty(type.Namespace))
     .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)
         && type.GetInterface("IEntityMap") != null);
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }



        public new IDbSet<T> Set<T>() where T : BaseEntity
        {

            return base.Set<T>();


        }

        public void SetDatabaseInitializer()
        {
            var initializer = new EfCreateDatabaseIfNotExists<SmartStoreDBContext>();
            Database.SetInitializer(initializer);

        }



        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry<TEntity>(entity);
        }

        public new void Dispose()
        {
            base.Dispose();
        }




        public int Execute(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommand(sql, parameters);
        }
        public IList<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters)
        {

            return this.Database.SqlQuery<TEntity>(sql, parameters).ToList();
        }


        public Database GetDateBase()
        {
            return base.Database;
        }
    }
}
