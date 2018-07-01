using Infrastructure.Cache;
using SmartStore.Manager.App.APP.APP;
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
                var appInfo = (UserApp)DependencyResolver.Current.GetService(typeof(UserApp));
                UserDto userInfo = appInfo.GetUserByName(model.Account);
                if (userInfo == null)
                {
                    throw new Exception("应用不存在");
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
              //  result.ReturnUrl = appInfo.ReturnUrl;
                result.Success = true;
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
