using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WxChallenge.Api.Services;
using WxChallenge.Core.Models;
using WxChallenge.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WxChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        private ISortService _sortService { get; set; }
        private IProductService _productService { get; set; }
        private IShopperService _shopperService { get; set; }

        public SortController(ISortService sortService, IProductService productService, IShopperService shopperService)
        {
            _sortService = sortService;
            _productService = productService;
            _shopperService = shopperService;
        }

        // GET: api/<Sort>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get(string sortOption)
        {
            var products = _productService.GetAll().Result;
            var sortedProducts = Enumerable.Empty<Product>();

            if (sortOption == "Recommended")
            {
                var shopperHistory = _shopperService.GetShopperHistory().Result;
                sortedProducts = _sortService.SortByPopularity(products, shopperHistory);
            }
            else
            {
                sortedProducts = _sortService.SortByField(products, sortOption);
            }

            return sortedProducts.ToList();
        }
    }
}
