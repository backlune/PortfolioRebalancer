using System;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioRebalancer
{
    public class Portfolio
    {
        public string Id { get; set; }
        public List<PortfolioAsset> Assets { get; set; }
        public void SetTagsFrom(Portfolio persisted)
        {
            foreach (var oldAsset in persisted.Assets)
            {
                var newAsset = Assets.SingleOrDefault(x => x.Name == oldAsset.Name); // Perhaps should change to Identifier to it´s not saved properly
                if(newAsset != null)
                {
                    newAsset.Tag = oldAsset.Tag;
                }
            }
        }
    }
}
