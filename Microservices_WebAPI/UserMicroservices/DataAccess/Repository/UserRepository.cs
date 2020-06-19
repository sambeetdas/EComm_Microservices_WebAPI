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
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserModel ProcessUser(UserModel user)
        {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@USERNAME", user.UserName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@PASSWORD", user.Password, DbType.String, ParameterDirection.Input);
                    parameters.Add("@FIRSTNAME", user.FirstName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@LASTNAME", user.LastName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@GEOLOCATIONID", user.GeoLocationId, DbType.Guid, ParameterDirection.Input);
                    parameters.Add("@PREFIX", user.Prefix, DbType.String, ParameterDirection.Input);
                    parameters.Add("@MIDDLEINIT", user.MiddleInit, DbType.String, ParameterDirection.Input);
                    parameters.Add("@SUFFIX", user.Suffix, DbType.String, ParameterDirection.Input);
                    parameters.Add("@MARITALSTATUS", user.MaritialStatus, DbType.String, ParameterDirection.Input);
                    parameters.Add("@GENDER", user.Gender, DbType.String, ParameterDirection.Input);
                    parameters.Add("@BIRTHDATE", user.BirthDate, DbType.String, ParameterDirection.Input);
                    parameters.Add("@COMPANYNAME", user.CompanyName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@SOURCECODE", user.SourceCode, DbType.String, ParameterDirection.Input);
                    parameters.Add("@PRIMARYPHONENUMBER", user.PrimaryPhoneNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add("@SECONDARYPHONENUMBER", user.SecondaryPhoneNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add("@PRIMARYPHONECOUNTRYCODE", user.PrimaryCountryCode, DbType.String, ParameterDirection.Input);
                    parameters.Add("@SECONDARYPHONECOUNTRYCODE", user.SecondaryCountryCode, DbType.String, ParameterDirection.Input);
                    parameters.Add("@ACCEPTSTEXT", user.AcceptsText, DbType.String, ParameterDirection.Input);
                    parameters.Add("@PRIMARYEMAIL", user.PrimaryEmail, DbType.String, ParameterDirection.Input);
                    parameters.Add("@SECONDARYEMAIL", user.SecondaryEmail, DbType.String, ParameterDirection.Input);
                    parameters.Add("@SOCIALTAGCODE", user.SocialTagCode, DbType.String, ParameterDirection.Input);
                    parameters.Add("@SOCIALUSERNAME", user.SocialUserName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@URL", user.Url, DbType.String, ParameterDirection.Input);

                    var result = connection.QueryFirstOrDefault<UserModel>("dbo.S_Process_User", parameters, commandType: CommandType.StoredProcedure);

                    return result;
                }

        }

        public UserModel GetUserById(Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@USERID", userId, DbType.Guid, ParameterDirection.Input);

                var result = connection.QueryFirstOrDefault<UserModel>("dbo.S_Get_User_By_Id", parameters, commandType: CommandType.StoredProcedure);

                return result;
            }

        }

        public UserModel GetUserByUserName(string username)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@USERNAME", username, DbType.String, ParameterDirection.Input);

                var result = connection.QueryFirstOrDefault<UserModel>("dbo.S_Get_User_By_User_Name", parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public UserModel GetUsers(UserModel user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserById(Guid userId)
        {
            throw new NotImplementedException();
        }

        //public async Task<UserModel> GetUserById(Guid userId)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        await connection.OpenAsync().ConfigureAwait(false);

        //        var parameters = new DynamicParameters();
        //        parameters.Add("@USERID", userId, DbType.Guid, ParameterDirection.Input);

        //        var result = await connection.QueryFirstOrDefaultAsync<UserModel>("dbo.S_Get_User_By_Id", parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

        //        return result;
        //    }

        //}

    }
}
