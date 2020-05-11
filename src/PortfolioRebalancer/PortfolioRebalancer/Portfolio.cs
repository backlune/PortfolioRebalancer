using System;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioRebalancer
{
    public class Portfolio
    {
        public string Id { get; set; }
        public List<PortfolioAsset> Assets { get; set; }

        public void SetModifiedData(Portfolio persisted)
        {
            foreach (var oldAsset in persisted.Assets)
            {
                var newAsset = Assets.SingleOrDefault(x => x.Name == oldAsset.Name); // Perhaps should change to Identifier to it´s not saved properly
                if(newAsset != null)
                {
                    newAsset.Tag = oldAsset.Tag;
                    newAsset.AllocationGoal = new AllocationGoal(oldAsset.AllocationGoal?.Allocation ?? 0, oldAsset.AllocationGoal?.Leverage ?? 1);
                }
            }
        }
    }
}
