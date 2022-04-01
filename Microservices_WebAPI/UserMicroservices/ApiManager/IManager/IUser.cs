using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager.IManager
{
    public interface IUser
    {
        UserModel ProcessUser(UserModel user);
        UserModel GetUserById(Guid userId);
        UserModel GetUserByUserName(string username);
    }
}
