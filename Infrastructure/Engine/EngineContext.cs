﻿using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Engine
{
    public class EngineContext
    {
        //public  class EngineContext<IClass, cbClass> where IClass: class where cbClass : class
        //  {


        //      public static IClass Current()
        //      {
        //          var container = new UnityContainer();
        //        //  container.RegisterType<IClass, cbClass>();
        //          container.RegisterType(typeof(IClass), typeof(cbClass));
        //          IClass ins = container.Resolve<IClass>();

        //          return ins;
        //      }
        //  }
        private static EngineCt _currentIOC;
        private static string _localeSetting;

        public static EngineCt Current
        {
            get { return _currentIOC ?? (_currentIOC = new EngineCt()); }
        }
    }
}
