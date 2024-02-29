using EventData.REPOSITORY;
using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusiness.Services
{
    public class UserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo) 
        {
            _userRepo = userRepo;
        }

        public bool AddUser(UserModel userdata)
        {
            return _userRepo.CreateUser(userdata);
        }

        public UserModel GetUser(int id)
        {
            return _userRepo.Get(id);
        }

        public IList<UserModel> GetUsers()
        {
            return _userRepo.GetAll();
        }

    }
}
