using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmtshop.Test.MmtShop.Data.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int CategoryMinSkuRange { get; set; }
        public int CategoryMaxSkuRange { get; set; }
        public bool Featured { get; set; }

        public ICollection<Product> productInfo { get; set; }
    }
}
