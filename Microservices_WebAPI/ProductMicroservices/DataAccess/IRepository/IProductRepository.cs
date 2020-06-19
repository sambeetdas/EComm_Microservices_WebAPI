using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IProductRepository
    {
        ProductModel ProcessProduct(ProductModel product);
        ProductModel GetProductBySku(String sku);
    }
}
