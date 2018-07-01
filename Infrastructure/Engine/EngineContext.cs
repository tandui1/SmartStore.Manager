using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Engine
{
  public  class EngineContext<IClass, cbClass> where IClass: class where cbClass : class
    {
      

        public static IClass Current()
        {
            var container = new UnityContainer();
            container.RegisterType(typeof(IClass), typeof(cbClass));
            IClass ins = (IClass)container.Resolve(typeof(IClass));

            return ins;
        }
    }
}
