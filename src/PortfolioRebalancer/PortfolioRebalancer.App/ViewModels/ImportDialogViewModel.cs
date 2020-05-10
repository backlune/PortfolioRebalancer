using PortfolioRebalancer.App.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PortfolioRebalancer.App.ViewModels
{
    public class ImportDialogViewModel : ViewModelBase
    {
        private readonly Database db;


        public ImportDialogViewModel(Database db)
        {
            this.db = db;
            StartImport = ReactiveCommand.Create(OnStartImport, this.WhenAnyValue(x => x.PortfolioId != default(int)));
        }


        private int portfolioId;
        public int PortfolioId
        {
            get => this.portfolioId;
            private set => this.RaiseAndSetIfChanged(ref this.portfolioId, value);
        }

        public ICommand StartImport { get; set; }

        private void OnStartImport()
        {
            var item = PortfolioImportService.Import("Enter you ssn", portfolioId); // TODO EB (2020-04-12): how to do this in an easy way? Not always 2 here!
            Portfolio persisted = this.db.Portfolios.FindOne(x => x.Id == portfolioId.ToString());
            if (persisted == null)
            {
                this.db.Portfolios.Insert(item);
            }
        }
    }
}
