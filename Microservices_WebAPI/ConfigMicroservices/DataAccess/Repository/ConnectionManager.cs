using DataAccess.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ConnectionManager : IConnectionManager
    {
        private readonly IConfiguration _configuration;
        public ConnectionManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            string dbConnectionString = _configuration.GetConnectionString("usercon");
            return dbConnectionString;
        }
    }
}
