using System;
using System.Collections.Generic;

namespace PortfolioRebalancer
{
    public class Asset
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public decimal Units { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ValueDomesticCurrency { get; set; }

    }
}
