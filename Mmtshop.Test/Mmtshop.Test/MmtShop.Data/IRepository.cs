using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mmtshop.Test.MmtShop.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);



    }
}
