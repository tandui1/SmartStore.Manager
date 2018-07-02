using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Infrastructure.Engine
{
    public class ApiDependencyScope : IDependencyScope
    {
        protected IContainer container;

        public ApiDependencyScope(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {

            return EngineContext.Current.ContainerManager.ResolveOptional(serviceType);

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var type = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)EngineContext.Current.Resolve(type);
        }

        public void Dispose()
        {
            //AutofacRequestLifetime.LifetimeScopeDisposable();
            //container.Dispose();
        }



    }

    public class IoCContainer : ApiDependencyScope, System.Web.Http.Dependencies.IDependencyResolver
    {

        public IoCContainer(IContainer container)
            : base(container)
        {
        }

        public IDependencyScope BeginScope()
        {
            return new ApiDependencyScope(container);

        }

    }
}
