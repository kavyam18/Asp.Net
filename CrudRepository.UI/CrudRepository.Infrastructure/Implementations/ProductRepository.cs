using CrudRepository.Core;
using CrudRepository.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudRepository.Infrastructure.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext Context)
        {
            this.dbContext = Context;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            var products =  await dbContext.Products.ToListAsync();
            return products;
        }
        public async Task<Product> GetById(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }
        public async Task Add(Product model)
        {
            await dbContext.AddAsync(model);
            await Save();
        }
        public async Task Update(Product model)
        {
            var product = await dbContext.Products.FindAsync(model.Id);
            if (product != null)
            {
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Qty = model.Qty;
                dbContext.Update(product);
                await Save();
            }
        }
        public async Task Delete(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product != null)
            {
                dbContext.Products.Remove(product);
                await Save();
            }
        }
        private async Task Save()
        {
           await dbContext.SaveChangesAsync();
        }
    }
}
