using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PortfolioRebalancer.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
		public MainWindowViewModel()
		{
			ImportPortfolio = ReactiveCommand.Create(OnImportPortfolio);
		}

        public string Greeting => "Welcome to PortfolioRebalancer";

		public ICommand ImportPortfolio { get; set; }
		private void OnImportPortfolio()
		{
			throw new NotImplementedException();
		}

	}
}
