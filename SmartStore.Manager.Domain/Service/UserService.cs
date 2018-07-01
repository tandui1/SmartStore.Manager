using SmartStore.Manager.Domain.Service.IService;
using SmartStore.Manager.Dto;
using SmartStore.Manager.Model;
using SmartStore.Manager.Service.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Domain.Service
{
  public  class UserService: BaseService<User, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public UserDto GetUser(Guid oid)
        {
            return  AutoMapper.Mapper.Map<UserDto>(this._userRepository.GetUser(oid));
        }
        public UserDto GetUserByName(string name)
        {
            return AutoMapper.Mapper.Map<UserDto>(this._userRepository.GetUserByName(name));
        }
    }
}
