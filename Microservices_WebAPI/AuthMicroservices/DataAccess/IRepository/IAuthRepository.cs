using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IAuthRepository
    {
        bool ValidateUser(AuthModel auth);
    }
}
