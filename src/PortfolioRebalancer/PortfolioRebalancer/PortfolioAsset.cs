using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

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

        public AllocationGoal AllocationGoal { get; set; }

        // TODO EB (2020-04-28): This method is dependent on trading plattform also should be possible to simplify alot
        public static PortfolioAsset CreateFromRawData(string name, string units, string unitPrice, string valueSEK)
        {
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;

            var asset = new PortfolioAsset { Name = name };
            asset.Identifier = name; // TODO EB (2020-04-05): Maybe change, fetch a different identifier

            asset.Units = Decimal.Parse(units.Replace(',', '.').Replace(" ", ""), style);

            var unitPriceSplit = unitPrice.Split(' ');
            asset.Currency = unitPriceSplit.Last();

            var cleanedUnitPriceString = Regex.Replace(string.Join("", unitPriceSplit.Take(unitPriceSplit.Length > 1 ? unitPriceSplit.Length - 1 : 1)).Replace(',', '.'), @"\s+", "");
            asset.UnitPrice = Decimal.Parse(cleanedUnitPriceString, style);

            var valueSEKSplit = valueSEK.Split(' ');
            var cleanedvalueSEKString = Regex.Replace(string.Join("", valueSEKSplit.Take(valueSEKSplit.Length > 2 ? valueSEKSplit.Length - 1 : 2)).Replace(',', '.'), @"\s+", "");
            asset.ValueDomesticCurrency = Decimal.Parse(cleanedvalueSEKString, style);

            return asset;
        }

    }
}
