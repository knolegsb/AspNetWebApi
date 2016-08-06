using AspNetWebApi.Data;
using AspNetWebApi.Models;
using AspNotWebApi.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebApi.Controllers
{
    public class ProductController : ApiController
    {
        //private List<Product> products = new List<Product>()
        //{
        //    //new Product { Id = 1, Name = "T Shirt", Price = 26.2M, Quantity = 5},
        //    //new Product { Id = 2, Name = "T Shirt 2", Price = 12.5M, Quantity = 2 }
        //};
        //public IEnumerable<Product> Get()
        //{
        //    return products.ToList();
        //}

        //public IHttpActionResult Get(int id)
        //{
        //    var product = products.Where(x => x.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}

        private IProductService productService = new ProductService();

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productService.GetProducts();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var product = productService.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [AcceptVerbs("PUT", "POST")]
        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            var isSave = productService.SaveProduct(product);

            if (isSave == true)
                return Ok(true);

            return BadRequest();            
        }

        [HttpPut]
        public IHttpActionResult Put(Product product)
        {
            var isUpdated = productService.UpdateProduct(product.Id, product);

            if (isUpdated == true)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var isDeleted = productService.DeleteProduct(id);
            if (isDeleted == true)
                return Ok();
            return BadRequest();
        }
    }
}
