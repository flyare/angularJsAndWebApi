using AngularJsDemo.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AngularJsDemo.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);

        Product Get(Product entity);

        Product Update(Product entity);

        Product Delete(int id);

        Product Add(Product entity);
    }

    public class ProductRepository : IProductRepository
    {
        private DatabaseDBContext dbContext = new DatabaseDBContext();

        public Product Add(Product entity)
        {
            dbContext.Products.Add(entity);
            dbContext.SaveChanges();

            return dbContext.Products.FirstOrDefault(x => x.Id.Equals(entity.Id));
        }

        public Product Delete(int id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id.Equals(id));

            dbContext.Products.Remove(product);
            dbContext.SaveChanges();

            return product;
        }

        public Product Get(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products;
        }

        public Product GetById(int id)
        {
            return dbContext.Products.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Product Update(Product entity)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id.Equals(entity.Id));            

            if(product != null)
            {
                product.Name = entity.Name;
                product.Category = entity.Category;
                product.Price = entity.Price;
                product.Status = entity.Status;
                dbContext.SaveChanges();                
            }            

            return product;
        }
    }
}