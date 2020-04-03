using System;
using System.Collections.Generic;

namespace PortfolioRebalancer
{
    public class Portfolio
    {
        public string Id { get; set; }
        public List<PortfolioAsset> Assets { get; set; }
    }
}
