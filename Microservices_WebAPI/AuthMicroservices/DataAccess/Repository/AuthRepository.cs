using Dapper;
using DataAccess.IRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly string _connectionString;

        public AuthRepository(string connectionString)
        {
            _connectionString = connectionString;
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
