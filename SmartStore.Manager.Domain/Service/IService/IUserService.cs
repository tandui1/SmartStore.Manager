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
        UserDto GetUser(Guid oid);
    }
}
