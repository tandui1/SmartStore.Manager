using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Dto
{
  public  class UserDto
    {
        public Guid OID { get; set; }
        /// <summary>
        /// 用户登录帐号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
	    /// 密码
	    /// </summary>
        public string Password { get; set; }
        /// <summary>
	    /// 用户姓名
	    /// </summary>
        public string Name { get; set; }
    }
}
