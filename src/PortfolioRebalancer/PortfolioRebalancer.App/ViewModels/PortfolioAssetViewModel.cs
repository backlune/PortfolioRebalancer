using ReactiveUI;

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
                ValueDomesticCurrency = asset.ValueDomesticCurrency
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
    }
}
