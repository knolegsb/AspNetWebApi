using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetWebApi.Data;
using System.Data;

namespace AspNotWebApi.Service.Services
{
    public class ProductService : IProductService
    {
        private AspNetWebApiProductEntities db = new AspNetWebApiProductEntities();        

        public Product GetProduct(int id)
        {
            var product = db.Products.Where(p => p.Id == id).FirstOrDefault();
            return product;
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public bool SaveProduct(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool UpdateProduct(int p, Product product)
        {
            try
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                var product = db.Products.Where(x => x.Id == id).FirstOrDefault();
                if (product == null)
                    return false;
                db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}