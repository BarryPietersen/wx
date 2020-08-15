using System.Collections.Generic;

namespace WxChallenge.Core.Models
{
    public class TrolleyDetail
    {
        public IEnumerable<PriceDetail> Products { get; set; }
        public IEnumerable<Special> Specials { get; set; }
        public IEnumerable<QuantityDetail> Quantities { get; set; }
    }

    public class PriceDetail 
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class QuantityDetail 
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
    public class Special
    {
        public IEnumerable<QuantityDetail> Quantities { get; set; }
        public double Total { get; set; }
    }
}
