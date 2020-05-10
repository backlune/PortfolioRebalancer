using PortfolioRebalancer.App.Services;
using ReactiveUI;
using System.Windows.Input;

namespace PortfolioRebalancer.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Database db;

        public MainWindowViewModel(Database db)
        {
            this.db = db;
            Content = new PortfolioViewModel(db, "2");
            ImportPortfolio = ReactiveCommand.Create(OnImportPortfolio);
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

        private void OnImportPortfolio()
        {
            var item = PortfolioImportService.Import("Enter you ssn", 2); // TODO EB (2020-04-12): how to do this in an easy way? Not always 2 here!
            Portfolio persisted = this.db.Portfolios.FindOne(x => x.Id == "2");
            if (persisted == null)
            {
                this.db.Portfolios.Insert(item);
            }
            item.SetTagsFrom(persisted);

            Content = new PortfolioViewModel(this.db, item);
        }
    }
}
