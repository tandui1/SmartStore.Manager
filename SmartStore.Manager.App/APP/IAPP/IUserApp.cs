using SmartStore.Manager.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.App.APP.IAPP
{
  public  interface IUserApp
    {
        UserDto GetUserByName(string name);
    }
}
