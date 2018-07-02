using Infrastructure.Cache;
using Infrastructure.Engine;
using Infrastructure.OkReponse;
using Microsoft.Practices.Unity;
using SmartStore.Manager.App.APP.APP;
using SmartStore.Manager.App.APP.IAPP;
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
        // private   IUserApp _appinfo;
        //public SSOAuthUtil(IUserApp appinfo)
        //{
        //    this._appinfo = appinfo;
        //}
        public static  LoginResult  Parse(LoginRequestDto model) {
        

            var result = new LoginResult();
            try
            {
                model.Trim();
                //EngineContext.Current.Resolve<IRoleService>().GetRoleByGuiD(i.User.RoleGuid).Name)
                // var container = new UnityContainer();
                //container.RegisterType<IUserApp, UserApp>();
                //获取应用信息
                //  var appInfo = EngineContext<IUserApp, UserApp>.Current();
                var appInfo = EngineContext.Current.Resolve<IUserApp>();
                //if (appInfo == null)
                //{
                //    throw new Exception("用户不存在");
                //}
                OkReponse okReponse = new OkReponse();
                UserDto userInfo= appInfo.GetUserByName(model.Account);
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
                    CreateTime = DateTime.Now,
                    IpAddress = HttpContext.Current.Request.UserHostAddress
                };
                //创建Session
                new ObjCacheProvider<UserAuthSession>().Create(currentSession.Token, currentSession, DateTime.Now.AddDays(10));
                result.Code = 200;
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
