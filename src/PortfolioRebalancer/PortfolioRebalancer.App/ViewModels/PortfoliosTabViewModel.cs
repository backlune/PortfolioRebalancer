using PortfolioRebalancer.App.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace PortfolioRebalancer.App.ViewModels
{
    public class PortfoliosTabViewModel : ViewModelBase
    {
        private readonly Database db;
        public PortfoliosTabViewModel(Services.Database db)
        {
            this.db = db;

            Portfolios = new ObservableCollection<PortfolioViewModel>();
            foreach (var item in db.Portfolios.FindAll())
            {
                Portfolios.Add(new PortfolioViewModel(db, item));
            }
        }
        private ObservableCollection<PortfolioViewModel> portfolios;
        public ObservableCollection<PortfolioViewModel> Portfolios
        {
            get => this.portfolios;
            set => this.RaiseAndSetIfChanged(ref portfolios, value);
        }

        private PortfolioViewModel selectedPortfolio;
        public PortfolioViewModel SelectedPortfolio
        {
            get => this.selectedPortfolio;
            set => this.RaiseAndSetIfChanged(ref selectedPortfolio, value);
        }




    }
}
