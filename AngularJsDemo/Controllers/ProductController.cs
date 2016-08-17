using System.Collections.Generic;
using System.Web.Http;
using AngularJsDemo.Models;
using AngularJsDemo.Repository;

namespace AngularJsDemo.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProductRepository _repository = new ProductRepository();

        [Route("getall")]
        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();
        }

        [Route("getbyid")]
        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        [Route("update")]
        [HttpPut]
        public Product Put(Product product)
        {
            return _repository.Update(product);
        }

        [Route("delete")]
        [HttpDelete]
        public Product Delete(int id)
        {
            return _repository.Delete(id);
        }

        [Route("add")]
        [HttpPost]
        public Product Post(Product product)
        {
            return _repository.Add(product);
        }
    }
}