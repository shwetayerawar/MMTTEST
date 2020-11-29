using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mmtshop.Test.MmtShop.Business;
using Mmtshop.Test.MmtShop.Data.Models;
using Mmtshop.Test.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmtshop.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;

        }

        [HttpGet]
        public async Task<ActionResult<Product>> Get()
        {
            var result = await productService.GetProducts();
            return Ok(result.Select(x => new ProductReponse() { 
                ProductName = x.ProductName , 
                ProductDesciption = x.ProductDescription ,
                Price = x.Price , 
                SKU = x.SKU
                    
            }));
        }

       
        [HttpGet("featured")]
       
        public async Task<ActionResult<Product>> GetFeaturedProducts()
        {
            var result = await productService.GetFeaturedProducts();

            return Ok(result.Select(x => new ProductReponse()
            {
                ProductName = x.ProductName,
                ProductDesciption = x.ProductDescription,
                Price = x.Price,
                SKU = x.SKU

            }));
        }


        [HttpGet("category/{categoryID}")]

        public async Task<ActionResult<Product>> GetProductsByCategory(int categoryID)
        {
            var result = await productService.GetProductsByCategory(categoryID);

            return Ok(result.Select(x => new ProductReponse()
            {
                ProductName = x.ProductName,
                ProductDesciption = x.ProductDescription,
                Price = x.Price,
                SKU = x.SKU

            }));
        }
    }
}
