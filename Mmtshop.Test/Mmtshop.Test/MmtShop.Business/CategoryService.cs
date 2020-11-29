using Mmtshop.Test.MmtShop.Data;
using Mmtshop.Test.MmtShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmtshop.Test.MmtShop.Business
{
    public class CategoryService : ICategoryService
    {

        private readonly IRepository<Category> repository;

        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;

        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await repository.GetAll();
        }
                
    }
}
