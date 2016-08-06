using AspNetWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNotWebApi.Service.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(int id);

        bool SaveProduct(Product product);
        bool UpdateProduct(int p, Product product);
        bool DeleteProduct(int id);
    }
}
