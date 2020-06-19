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
    public class GeoRepository : IGeoRepository
    {
        private readonly string _connectionString;

        public GeoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public GeoLocationModel GetGeoLocation()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.QueryFirstOrDefault<GeoLocationModel>("dbo.S_Get_Geolocation", commandType: CommandType.StoredProcedure);

                return result;
            }

        }      

    }
}
