using Infrastructure.Cache;
using SmartStore.Manager.App.SSO.Login;
using SmartStore.Manager.Domain.Service;
using SmartStore.Manager.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SmartStore.Manager.App.SSO
{
   public class SSOAuthUtil
    {
        public static LoginResult Parse(PassportLoginRequest model) {
            var result = new LoginResult();
            try
            {
                model.Trim();
                //获取应用信息
                var appInfo = new AppInfoService().Get(model.AppKey);
                if (appInfo == null)
                {
                    throw new Exception("应用不存在");
                }
               // 获取用户信息
                UserDto userInfo = null;
                if (model.Account == "admin")
                {
                    userInfo = new UserDto
                    {
                        OID = Guid.Empty,  //TODO:可以根据需要调整
                        Account = "admin",
                        Name = "admin",
                        Password = "123456"
                    };
                }
                else
                {
                    var usermanager = (UserService)DependencyResolver.Current.GetService(typeof(UserService));
                    userInfo = usermanager.GetUserByName(model.Account);
                }

                if (userInfo == null)
                {
                    throw new Exception("用户不存在");
                }
                if (userInfo.Password != model.Password)
                {
                    throw new Exception("密码错误");
                }

                var currentSession = new UserAuthSession
                {
                    UserName = model.Account,
                    Token = Guid.NewGuid().ToString().GetHashCode().ToString("x"),
                    AppKey = model.AppKey,
                    CreateTime = DateTime.Now,
                    IpAddress = HttpContext.Current.Request.UserHostAddress
                };

                //创建Session
                new ObjCacheProvider<UserAuthSession>().Create(currentSession.Token, currentSession, DateTime.Now.AddDays(10));

                result.Code = 200;
                result.ReturnUrl = appInfo.ReturnUrl;
                result.Token = currentSession.Token;
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
