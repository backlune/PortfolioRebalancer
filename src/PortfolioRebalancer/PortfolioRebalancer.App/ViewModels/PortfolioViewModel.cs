﻿using PortfolioRebalancer.App.Services;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PortfolioRebalancer.App.ViewModels
{
    public class TagGoal
    {
        public TagGoal()
        {
        }
        public string Tag { get; set; }
        public decimal Value { get; set; }
    }
    public class PortfolioViewModel : ViewModelBase
    {
        private Database db;
        private Portfolio Portfolio;

        public PortfolioViewModel(Database db, string id)
        {
            var item = db.Portfolios.FindOne(x => x.Id == id);
            Initialize(db, item);
        }

        public PortfolioViewModel(Database db, Portfolio item)
        {
            Initialize(db, item);
        }

        private void Initialize(Database db, Portfolio item)
        {
            this.db = db;
            this.Portfolio = item;
            Assets = new ObservableCollection<PortfolioAssetViewModel>(item.Assets.Select(PortfolioAssetViewModel.FromAsset));
            foreach (var asset in Assets)
            {
                asset.PropertyChanged += (s, e) => this.RaisePropertyChanged(nameof(AssetsByTag));
                asset.PropertyChanged += (s, e) => this.RaisePropertyChanged(nameof(TagGoals));
                asset.PropertyChanged += (s, e) => this.RaisePropertyChanged(nameof(TotalGoalSet));
            }

            SavePortfolioCommand = ReactiveCommand.Create(OnSavePortfolio);
            Name = $"Portfolio: {item.Id}";
        }

        private string name;
        public string Name
        {
            get => this.name;
            private set => this.RaiseAndSetIfChanged(ref this.name, value);
        }

        public ICommand SavePortfolioCommand { get; set; }

        private ObservableCollection<PortfolioAssetViewModel> assets;

        public ObservableCollection<PortfolioAssetViewModel> Assets
        {
            get => this.assets;
            private set
            {
                this.RaiseAndSetIfChanged(ref this.assets, value);
                this.RaisePropertyChanged(nameof(AssetsByTag));
            }
        }

        public ObservableCollection<TagAssetGroup> AssetsByTag
        {
            get
            {
                var tagGroups = this.assets.Select(x => new { Tag = x.Tag, Value = x.ValueDomesticCurrency }).GroupBy(x => x.Tag).Select(x => new TagAssetGroup
                {
                    Tag = x.Key,
                    Value = x.Sum(y => y.Value)
                });
                return new ObservableCollection<TagAssetGroup>(tagGroups);
            }
        }

        public ObservableCollection<TagGoal> TagGoals
        {
            get
            {
                var tagGoals = this.assets.Select(x => new { Tag = x.Tag, Value = x.GoalAllocation * x.GoalLeverage }).GroupBy(x => x.Tag).Select(x => new TagGoal
                {
                    Tag = x.Key,
                    Value = x.Sum(y => y.Value)
                });
                return new ObservableCollection<TagGoal>(tagGoals);
            }
        }

        public decimal TotalGoalSet => assets.Sum(x => x.GoalAllocation);

        private void OnSavePortfolio()
        {
            this.Portfolio.Assets = Assets.ToEntities();
            this.db.Portfolios.Update(this.Portfolio);
        }
    }
}
