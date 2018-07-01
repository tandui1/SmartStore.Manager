using SmartStore.Manager.Dto;
using SmartStore.Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Domain.Service.IService
{
  public  interface IUserService: IBaseService<User, UserDto>
    {
        /// <summary>
        /// 根据oid查询用户对象
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        UserDto GetUser(Guid oid);
        /// <summary>
        /// 根据用户名查询用户对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        UserDto GetUserByName(string name);
    }
}
