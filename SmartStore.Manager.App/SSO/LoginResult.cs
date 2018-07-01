using SmartStore.Manager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.App.SSO
{
   public class LoginResult : Response<string>
    {
        public bool Success;
        public string ErrorMsg;
        public string ReturnUrl;
        public string Token;
    }
    public class LoginResultResponse
    {
        public bool Success;
        public string ErrorMsg;
        public string ReturnUrl;
        public string Token;

    }
}
