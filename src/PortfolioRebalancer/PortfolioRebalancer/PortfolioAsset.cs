using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
        public string Currency { get; set; }

        // TODO EB (2020-04-28): This method is dependent on trading plattform
        public static PortfolioAsset CreateFromRawData(string name, string units, string unitPrice, string valueSEK)
        {
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;

            var asset = new PortfolioAsset { Name = name };
            asset.Identifier = name; // TODO EB (2020-04-05): Maybe change, fetch a different identifier

            asset.Units = Decimal.Parse(units.Replace(',', '.').Replace(" ",""), style);

            var unitPriceSplit = unitPrice.Split(' ');
            asset.Currency = unitPriceSplit.Last();
            asset.UnitPrice = Decimal.Parse(string.Join("", unitPriceSplit.Reverse().Skip(1)).Replace(',', '.').Replace(" ", ""), style);
            
            asset.ValueDomesticCurrency = Decimal.Parse(valueSEK.Replace(',', '.').Replace(" ", ""), style);

            return asset;
        }

    }
}
