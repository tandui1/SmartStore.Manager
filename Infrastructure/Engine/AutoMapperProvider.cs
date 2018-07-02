using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Engine
{
   public class AutoMapperProvider
    {
        public static void Init()
        {
            //AutoMapper.Mapper.Initialize(cgf =>
            //{
            //    var dependncyTypes = EngineContext.Current.Resolve<ITypeFinder>().FindClassesOfType<IAutoMapperConfig>();
            //    foreach (var dependncyType in dependncyTypes)
            //    {
            //        ((IAutoMapperConfig)Activator.CreateInstance(dependncyType)).Init(cgf);
            //    }
            //});
        }
    }
}