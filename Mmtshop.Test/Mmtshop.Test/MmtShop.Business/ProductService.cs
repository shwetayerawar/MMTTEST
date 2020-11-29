using Mmtshop.Test.MmtShop.Data;
using Mmtshop.Test.MmtShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmtshop.Test.MmtShop.Business
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> repository;

        public ProductService(IRepository<Product> repository)
        {
            this.repository = repository;

        }

        public async Task<IEnumerable<Product>> GetFeaturedProducts()
        {
            return await repository.GetAll(x => x.category.Featured);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await repository.GetAll();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int category)
        {
            return await repository.GetAll(x => x.CategoryID == category);
        }
    }
}
