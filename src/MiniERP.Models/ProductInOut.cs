using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Models
{
    public class ProductInOut : BaseIdentifier
    {
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        public decimal? QuantityIn { get; set; }

        public decimal? QuantityOut { get; set; }

        public decimal Price { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal AveragePrice { get; set; }
    }
}

