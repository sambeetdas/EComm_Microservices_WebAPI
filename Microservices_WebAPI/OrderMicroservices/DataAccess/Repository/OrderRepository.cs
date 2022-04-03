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
    public class OrderRepository : ConnectionManager, IOrderRepository
    {
        private readonly IConfiguration _configuration;
        public OrderRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        //public OrderModel PlaceOrder(OrderModel order)
        //{
        //        using (var connection = new SqlConnection(GetConnection()))
        //        {
        //            connection.Open();

        //            var parameters = new DynamicParameters();
        //            parameters.Add("@TITLE", product.Title, DbType.String, ParameterDirection.Input);
        //            parameters.Add("@DESCRIPTION", product.Description, DbType.String, ParameterDirection.Input);
        //            parameters.Add("@FIRSTCATEGORY", product.FirstCategory, DbType.String, ParameterDirection.Input);
        //            parameters.Add("@SECONDCATEGORY", product.SecondCategory, DbType.String, ParameterDirection.Input);
        //            parameters.Add("@THIRDCATEGORY", product.ThirdCategory, DbType.Guid, ParameterDirection.Input);
        //            parameters.Add("@AVAILABLEQUANTITY", product.AvailableQuantity, DbType.Int32, ParameterDirection.Input);
        //            parameters.Add("@ACTUALPRICE", product.ActualPrice, DbType.String, ParameterDirection.Input);
        //            parameters.Add("@DISCOUNTPRICE", product.DiscountPrice, DbType.String, ParameterDirection.Input);
        //            parameters.Add("@ISINSALE", product.IsInSale, DbType.String, ParameterDirection.Input);
        //            parameters.Add("@SKU", product.Sku, DbType.String, ParameterDirection.Input);
        //            parameters.Add("@GEOLOCATIONID", product.GeoLocationId, DbType.Guid, ParameterDirection.Input);


        //            var result = connection.QueryFirstOrDefault<OrderModel>("dbo.S_Process_Product", parameters, commandType: CommandType.StoredProcedure);

        //            return result;
        //        }

        //}

        public IEnumerable<OrderModel> GetOrderForUser(Guid userId)
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@USERID", userId, DbType.String, ParameterDirection.Input);

                var result = connection.QueryFirstOrDefault<IEnumerable<OrderModel>>("dbo.S_Get_Orders", parameters, commandType: CommandType.StoredProcedure);

                return result;
            }

        }      

    }
}
