using System.Collections.Generic;

namespace WxChallenge.Core.Models
{
    public class ShopperHistory
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
