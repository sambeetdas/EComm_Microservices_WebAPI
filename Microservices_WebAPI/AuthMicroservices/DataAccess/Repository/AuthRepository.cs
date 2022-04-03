using Dapper;
using DataAccess.IRepository;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AuthRepository : ConnectionManager, IAuthRepository
    {
        private readonly IConfiguration _configuration;
        public AuthRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public bool ValidateUser(AuthModel auth)
        {
            if (auth.UserName == "admin" && auth.UserName == "admin")
            {
                return true;
            }

            return false;

        }      

    }
}
