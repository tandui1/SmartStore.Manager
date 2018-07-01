using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using SmartStore.Manager.Core.Base;
using SmartStore.Manager.Core.Repository;

namespace SmartStore.Manager.Core.Applocation
{
    public class Infrastructure : IDependencyRegistrar
    {
        public int Order()
        {
            return 0;
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.Register<IDbContext>(x => new SmartStoreDBContext(CommonLogic.Application("DBCon"))).InstancePerLifetimeScope();
            // builder.Register<IDbContext>(x => new EfDBContext(CommonLogic.Application("TerminalDBCon"))).Named<IDbContext>("Terminal").InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EntityBaseRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            // builder.RegisterGeneric(typeof(EfUnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
         //   builder.Register<IUnitOfWork>(x => new EfUnitOfWork()).InstancePerLifetimeScope();
           builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
            builder.RegisterApiControllers(typeFinder.GetAssemblies().ToArray());
        }
    }
}
