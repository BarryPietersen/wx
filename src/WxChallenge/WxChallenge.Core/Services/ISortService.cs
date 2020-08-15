using System.Collections.Generic;
using WxChallenge.Core.Models;

namespace WxChallenge.Core.Services
{
    public interface ISortService
    {
        IEnumerable<Product> SortByField(IEnumerable<Product> products, string sortOrder);
        IEnumerable<Product> SortByPopularity(IEnumerable<Product> products, IEnumerable<ShopperHistory> histories);
    }
}