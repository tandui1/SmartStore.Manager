using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace SmartStore.Manager.Core.Applocation
{
  public  class CommonLogic
    {
        public static string Application(string paramName)
        {
            string str = string.Empty;
            if (WebConfigurationManager.AppSettings[paramName] == null)
            {
                return str;
            }
            try
            {
                return WebConfigurationManager.AppSettings[paramName];
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
