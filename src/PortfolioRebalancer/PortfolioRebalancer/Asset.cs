using System;
using System.Collections.Generic;

namespace PortfolioRebalancer
{
    public class PortfolioAsset
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public decimal Units { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ValueDomesticCurrency { get; set; }
        public string Tag { get; set; }

        public static PortfolioAsset CreateFromRawData(string name, string units, string unitPrice, string valueSEK)
        {
            var asset = new PortfolioAsset { Name = name };
            asset.Identifier = name; // TODO EB (2020-04-05): Maybe change, fetch a different identifier

            // TODO EB (2020-04-05): This will not be enough have seen 500 USD and similar here.
            asset.Units = Decimal.Parse(units);
            asset.UnitPrice = Decimal.Parse(unitPrice);
            asset.ValueDomesticCurrency = Decimal.Parse(valueSEK);

            return asset;
        }

    }
}
