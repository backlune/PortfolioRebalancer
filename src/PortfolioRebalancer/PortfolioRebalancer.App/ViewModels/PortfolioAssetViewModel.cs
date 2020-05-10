using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PortfolioRebalancer.App.ViewModels
{
    public class PortfolioAssetViewModel : ViewModelBase
    {
        public PortfolioAssetViewModel()
        {
        }

        public static PortfolioAssetViewModel FromAsset(PortfolioAsset asset)
        {
            return new PortfolioAssetViewModel
            {
                Name = asset.Name,
                Tag = asset.Tag,
                ValueDomesticCurrency = asset.ValueDomesticCurrency,
                GoalAllocation = asset.AllocationGoal?.Allocation ?? 0,
                GoalLeverage = asset.AllocationGoal?.Leverage ?? 1.0m,
            };
        }

        private string name;

        public string Name
        {
            get => this.name;
            private set => this.RaiseAndSetIfChanged(ref this.name, value);
        }

        private string tag;

        public string Tag
        {
            get => this.tag;
            private set => this.RaiseAndSetIfChanged(ref this.tag, value);
        }

        private decimal valueDomesticCurrency;

        public decimal ValueDomesticCurrency
        {
            get => this.valueDomesticCurrency;
            private set => this.RaiseAndSetIfChanged(ref this.valueDomesticCurrency, value);
        }

        private decimal goalAllocation;

        public decimal GoalAllocation
        {
            get => goalAllocation;
            set => this.RaiseAndSetIfChanged(ref goalAllocation, value);
        }

        private decimal goalLeverage;

        public decimal GoalLeverage
        {
            get => goalLeverage;
            set => this.RaiseAndSetIfChanged(ref goalLeverage, value);
        }


    }

    public static class PortfolioAssetViewModelExtenstions
    {
        public static List<PortfolioAsset> ToEntities(this ObservableCollection<PortfolioAssetViewModel> assets)
        {
            return assets.Select(x => new PortfolioAsset
                {
                    Name = x.Name,
                    Tag = x.Tag,
                    ValueDomesticCurrency = x.ValueDomesticCurrency,
                    AllocationGoal = new AllocationGoal(x.GoalAllocation, x.GoalLeverage)
                    // TODO EB (2020-04-12): Loosing some information on the entity here
                    
                }).ToList();
        }
    }
}
