using System;
using System.Linq;

namespace PortfolioRebalancer.App.ViewModels
{
    public class TagAssetGroup
    {
        public TagAssetGroup()
        {
        }

        public string Tag { get; set; }

        public decimal Value { get; set; }
    }
}
