using SmartStore.Manager.App.SSO.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.App.SSO
{
  public  class AppInfoService
    {
        public AppInfo Get(string appKey)
        {
           // return "";
            ////可以从数据库读取
            return _applist.SingleOrDefault(u => u.AppKey == appKey);
        }
        private AppInfo[] _applist = new[]
       {
            new AppInfo
            {
                AppKey = "openauth",
                IsEnable = true,
                ReturnUrl = "http://localhost:16791/",
                CreateTime = DateTime.Now,
            },
            new AppInfo
            {
                AppKey = "openauthtest",
                IsEnable = true,
                ReturnUrl = "http://localhost:16791/",
                CreateTime = DateTime.Now,
            }
        };
    }
}
