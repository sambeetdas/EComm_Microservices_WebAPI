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
    public class CartRepository : ConnectionManager, ICartRepository
    {
        private readonly IConfiguration _configuration;
        public CartRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<CartModel> ProcessCart(CartModel cart)
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@PRODUCTID", cart.ProductId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@USERID", cart.UserId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@USERNAME", cart.UserName, DbType.String, ParameterDirection.Input);
                parameters.Add("@QUANTITY", cart.Quantity, DbType.Int32, ParameterDirection.Input);
               
                var result = connection.QueryFirstOrDefault<IEnumerable<CartModel>>("dbo.S_Process_Cart", parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
        public dynamic ClearCart(Guid userId)
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@USERID", userId, DbType.Guid, ParameterDirection.Input);

                var result = connection.QueryFirstOrDefault("dbo.S_Clear_Cart", parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public dynamic DeleteCart(Guid userId, Guid productId)
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@PRODUCTID", productId, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@USERID", userId, DbType.Guid, ParameterDirection.Input);

                var result = connection.QueryFirstOrDefault("dbo.S_Delete_Cart", parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public IEnumerable<CartModel> GetCartForUser(Guid userId)
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@USERID", userId, DbType.Guid, ParameterDirection.Input);

                var result = connection.QueryFirstOrDefault<IEnumerable<CartModel>>("dbo.S_Get_Cart_By_User_Id", parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

    }
}
