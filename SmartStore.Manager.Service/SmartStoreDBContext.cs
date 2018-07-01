using SmartStore.Manager.Model;
using SmartStore.Manager.Repository.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Repository
{
    public class SmartStoreDBContext : DbContext
    {
        static SmartStoreDBContext()
        {
            Database.SetInitializer<SmartStoreDBContext>(null);
        }
        public SmartStoreDBContext()
           : base("Name=SmartStoreDBContext")
        { }

        public SmartStoreDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }
        public System.Data.Entity.DbSet<User> User { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
        }
        //public int A(string sql)
        //{
        //    DbContext
        //}
    }
}
