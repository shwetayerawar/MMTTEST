using Mmtshop.Test.MmtShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmtshop.Test.MmtShop.Business
{
    public interface ICategoryService 
    {

        Task<IEnumerable<Category>> GetCategories();
       
    }
}
