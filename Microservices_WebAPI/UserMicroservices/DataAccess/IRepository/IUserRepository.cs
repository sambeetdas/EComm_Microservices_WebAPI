using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IUserRepository
    {
        UserModel ProcessUser(UserModel user);
        UserModel GetUserById(Guid userId);
        //Task<UserModel> GetUserById(Guid UserId);
        UserModel GetUserByUserName(string username);
        UserModel GetUsers(UserModel user);
        Boolean DeleteUserById(Guid userId);
    }
}
