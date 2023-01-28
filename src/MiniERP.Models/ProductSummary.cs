using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Models
{
    public class ProductSummary : BaseIdentifier
    {
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal LastPriceSell { get; set; }

        public decimal LastPriceBuy { get; set; }

        public decimal Quantity { get; set; }
    }
}
