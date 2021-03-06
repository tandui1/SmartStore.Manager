﻿using Infrastructure.Engine;
using SmartStore.Manager.App.APP.IAPP;
using SmartStore.Manager.Domain.Service;
using SmartStore.Manager.Domain.Service.IService;
using SmartStore.Manager.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.App.APP.APP
{
   public class UserApp: IUserApp
    {
        private readonly IUserService _userService;
        public UserApp(IUserService userService)
        {
            this._userService = userService;
        }
        public UserApp()
        {

        }
        public UserDto GetUserByName(string name)
        {
            return _userService.GetUserByName(name);
        }
    }
}
