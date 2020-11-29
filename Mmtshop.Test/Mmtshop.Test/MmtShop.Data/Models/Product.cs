using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmtshop.Test.MmtShop.Data.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set;}
        public int CategoryID { get; set; }

        public  Category category { get; set; }

    }
}
