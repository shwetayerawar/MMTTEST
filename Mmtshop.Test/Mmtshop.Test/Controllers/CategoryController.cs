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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;

        }

        [HttpGet]
        public  async Task<ActionResult<CategoryReponse>> Get()
        {
            var result = await categoryService.GetCategories();
                       
            return Ok(result.Select(x => new CategoryReponse()
            {
                CategoryName = x.CategoryName,
                
            }));
        }

    }
}
