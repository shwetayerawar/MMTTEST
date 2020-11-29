using Microsoft.EntityFrameworkCore;
using Mmtshop.Test.MmtShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mmtshop.Test.MmtShop.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class , IEntity
    {
        private readonly ProductsContext productContext;

        public Repository(ProductsContext productContext)
        {
            this.productContext = productContext;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await productContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await productContext.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetById(int id)
        {
            return (IEnumerable<TEntity>)await productContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
    }

}
