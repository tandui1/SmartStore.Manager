using SmartStore.Manager.Model;
using SmartStore.Manager.Repository.Interface.Base;
using SmartStore.Manager.Service.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Service.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IBaseRepository<User> _userRepository;
        public UserRepository(IBaseRepository<User> userRepository) {
            this._userRepository = userRepository;

        }
        public User GetUser(Guid oid)
        {
          return  this._userRepository.FindSingle(a => a.OID == oid);
        }
        public User GetUserByName(string name)
        {
            return this._userRepository.FindSingle(a => a.Name==name);
        }
    }
}
