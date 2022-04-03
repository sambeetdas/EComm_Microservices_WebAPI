using DataAccess.IRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager.IManager
{
    public interface IProduct
    {
        ProductModel ProcessProduct(ProductModel product);
        ProductModel GetProductBySku(string sku);
    }
}
