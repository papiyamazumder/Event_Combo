using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData.REPOSITORY
{
    public interface IUserRepo
    {
        bool CreateUser(UserModel userdata);
        UserModel Get(int id);
        IList<UserModel> GetAll();

    }
}
