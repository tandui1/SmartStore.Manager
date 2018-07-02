using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Engine
{
  public  class EngineCt
    {
        private ContainerManager _containerManager;


        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
            set { _containerManager = value; }
        }

        public void InitializeContainer()
        {

            var builder = new ContainerBuilder();

            _containerManager = new ContainerManager(builder.Build());

            _containerManager.AddComponent<ITypeFinder, BaseTypeFinder>("hihilulu.typeFinder");

            var typeFinder = _containerManager.Resolve<ITypeFinder>();

            var dependncyTypesList = new List<IDependencyRegistrar>();
            var dependncyTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();

            foreach (var dependncyType in dependncyTypes)
                dependncyTypesList.Add((IDependencyRegistrar)Activator.CreateInstance(dependncyType));

            _containerManager.UpdateContainer(x =>
            {
                foreach (var dependncy in dependncyTypesList)
                    dependncy.Register(x, typeFinder);
            });



        }

        public T Resolve<T>() where T : class
        {
           // var a = new ContainerManager();
             var a = _containerManager;
            return _containerManager.Resolve<T>();
        }
        public object Resolve(Type type)
        {
            return _containerManager.Resolve(type);
        }

    }
}
