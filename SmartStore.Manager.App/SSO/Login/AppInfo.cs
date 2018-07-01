using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.App.SSO.Login
{
   public class AppInfo
    {
        public string AppKey { get; set; }

        public string AppSecret { get; set; }

       
        public string ReturnUrl { get; set; }

        public bool IsEnable { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
