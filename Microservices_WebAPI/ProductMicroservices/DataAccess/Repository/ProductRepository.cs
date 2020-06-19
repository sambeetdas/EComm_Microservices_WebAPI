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
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ProductModel ProcessProduct(ProductModel product)
        {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@TITLE", product.Title, DbType.String, ParameterDirection.Input);
                    parameters.Add("@DESCRIPTION", product.Description, DbType.String, ParameterDirection.Input);
                    parameters.Add("@FIRSTCATEGORY", product.FirstCategory, DbType.String, ParameterDirection.Input);
                    parameters.Add("@SECONDCATEGORY", product.SecondCategory, DbType.String, ParameterDirection.Input);
                    parameters.Add("@THIRDCATEGORY", product.ThirdCategory, DbType.String, ParameterDirection.Input);
                    parameters.Add("@AVAILABLEQUANTITY", product.AvailableQuantity, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@ACTUALPRICE", product.ActualPrice, DbType.String, ParameterDirection.Input);
                    parameters.Add("@DISCOUNTPRICE", product.DiscountPrice, DbType.String, ParameterDirection.Input);
                    parameters.Add("@ISINSALE", product.IsInSale, DbType.String, ParameterDirection.Input);
                    parameters.Add("@SKU", product.Sku, DbType.String, ParameterDirection.Input);
                    parameters.Add("@GEOLOCATIONID", product.GeoLocationId, DbType.Guid, ParameterDirection.Input);
                    

                    var result = connection.QueryFirstOrDefault<ProductModel>("dbo.S_Process_Product", parameters, commandType: CommandType.StoredProcedure);

                    return result;
                }

        }

        public ProductModel GetProductBySku(String sku)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@SKU", sku, DbType.String, ParameterDirection.Input);

                var result = connection.QueryFirstOrDefault<ProductModel>("dbo.S_Get_Product_by_Sku", parameters, commandType: CommandType.StoredProcedure);

                return result;
            }

        }      

    }
}
