using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using PortfolioRebalancer.App.Services;
using PortfolioRebalancer.App.Views;
using ReactiveUI;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;

namespace PortfolioRebalancer.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Database db;

        public MainWindowViewModel(Database db)
        {
            this.db = db;
            if (this.db.Portfolios.Count() != 0)
            {
                Content = new PortfoliosTabViewModel(db);
            }
            ImportPortfolio = ReactiveCommand.CreateFromTask(OnImportPortfolio);
        }

        public string Greeting => "Welcome to PortfolioRebalancer. Start by importing your portfolio";

        public bool NoContent => Content == null;

        private ViewModelBase content;

        public ViewModelBase Content
        {
            get => content;
            private set
            {
                this.RaiseAndSetIfChanged(ref content, value);
                this.RaisePropertyChanged(nameof(NoContent));
            }
        }

        public ICommand ImportPortfolio { get; set; }

        //private void OnImportPortfolio()
        //{
            

        //    //const int portfolioId = 2;
        //    //var item = PortfolioImportService.Import("Enter you ssn", portfolioId); // TODO EB (2020-04-12): how to do this in an easy way? Not always 2 here!
        //    //Portfolio persisted = this.db.Portfolios.FindOne(x => x.Id == portfolioId.ToString());
        //    //if (persisted == null)
        //    //{
        //    //    this.db.Portfolios.Insert(item);
        //    //}
        //    //item.SetModifiedData(persisted);

        //    //Content = new PortfolioViewModel(this.db, item);
        //}

        public async Task OnImportPortfolio()
        {
            var dialog = new ImportDialog();
            var vm = new ImportDialogViewModel(this.db);
            dialog.DataContext = vm;

            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow);

            Content = new PortfolioViewModel(db, vm.PortfolioId.ToString());
        }
    }
}
