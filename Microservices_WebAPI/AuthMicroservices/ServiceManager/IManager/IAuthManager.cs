using Auth.JWT.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager.IManager
{
    public interface IAuthManager
    {
        TokenResponseModel CreateToken(AuthModel auth);
    }
}
