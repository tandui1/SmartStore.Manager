using SmartStore.Manager.Model;
using SmartStore.Manager.Repository.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Service.Interface.IRepository
{
  public  interface IUserRepository
    {
        User GetUser(Guid oid);
        User GetUserByName(string name);
    }
}
