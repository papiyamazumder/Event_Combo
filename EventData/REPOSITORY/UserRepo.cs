using EventData.DataContext;
using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData.REPOSITORY
{
    public class UserRepo : IUserRepo
    {
        private readonly EventDbContext _eventDbContext;
        public UserRepo(EventDbContext eventDbContext) 
        { 
            _eventDbContext = eventDbContext;
        }
        public bool CreateUser(UserModel userdata)
        {
            _eventDbContext.UserModel.Add(userdata);
            _eventDbContext.SaveChanges();
            return true;
        }

        public UserModel Get(int id)
        {
            UserModel userdata = _eventDbContext.UserModel.Find(id);
            return userdata;
        }

        public IList<UserModel> GetAll()
        {
            return _eventDbContext.UserModel.ToList();
        }
    }
}
