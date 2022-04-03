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
    public class GeoRepository : ConnectionManager, IGeoRepository
    {
        private readonly IConfiguration _configuration;
        public GeoRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public GeoLocationModel GetGeoLocation()
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();

                var result = connection.QueryFirstOrDefault<GeoLocationModel>("dbo.S_Get_Geolocation", commandType: CommandType.StoredProcedure);

                return result;
            }

        }      

    }
}
