using System;
using System.Collections.Generic;
using System.Linq;
using WxChallenge.Core.Models;

namespace WxChallenge.Core.Services
{
    public class SortService : ISortService
    {
        public SortService()
        {}

        public IEnumerable<Product> SortByField(IEnumerable<Product> products, string sortOption)
        {
            switch (sortOption)
            {
                case "Low":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "High":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                case "Ascending":
                    products = products.OrderBy(p => p.Name);
                    break;
                case "Descending":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                default:
                    throw new ApplicationException($"the sort order {sortOption} was not recognised");
            }

            return products;
        }
        public IEnumerable<Product> SortByPopularity(IEnumerable<Product> products, IEnumerable<ShopperHistory> histories)
        {
            Dictionary<string, int> popularities = new Dictionary<string, int>();

            foreach (var history in histories)
            {
                foreach (var product in history.Products)
                {
                    if (popularities.ContainsKey(product.Name))
                    {
                        popularities[product.Name]++;
                    }
                    else 
                    {
                        popularities.Add(product.Name, 1);
                    }
                }
            }

            // the key selector function performs a lookup of the items popularity rating, if any
            var result = products.OrderByDescending(p => popularities.ContainsKey(p.Name) ? popularities[p.Name] : 0).ToList();

            return products;
        }
    }
}
