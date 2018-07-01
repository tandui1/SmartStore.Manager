using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.App.SSO.Login
{
   public class PassportLoginRequest
    {
        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Key
        /// </summary>

        public string AppKey { get; set; }
        /// <summary>
        /// 用户基本验证
        /// </summary>
        public void Trim()
        {
            if (string.IsNullOrEmpty(Account))
            {
                throw new Exception("用户名不能为空");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("密码不能为空");
            }
            Account = Account.Trim();
            Password = Password.Trim();
            if (!string.IsNullOrEmpty(AppKey)) AppKey = AppKey.Trim();
        }
    }
}
