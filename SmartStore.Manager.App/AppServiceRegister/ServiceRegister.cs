using Autofac;
using Infrastructure.Engine;
using SmartStore.Manager.App.APP.APP;
using SmartStore.Manager.App.APP.IAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.App.AppServiceRegister
{
   public class ServiceRegister : IDependencyRegistrar
    {
        public int Order()
        {
            throw new NotImplementedException();
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<IUserApp>().As<UserApp>().InstancePerLifetimeScope();
         
        }
     }
}
