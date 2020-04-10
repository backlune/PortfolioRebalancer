using PortfolioRebalancer.App.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace PortfolioRebalancer.App.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private readonly Database db;

		public MainWindowViewModel(Database db)
		{
			this.db = db;
			ImportPortfolio = ReactiveCommand.Create(OnImportPortfolio);
		}

		public string Greeting => "Welcome to PortfolioRebalancer";

		private ViewModelBase _content;

		public ViewModelBase Content
		{
			get => this._content;
			private set => this.RaiseAndSetIfChanged(ref this._content, value);
		}

		public ICommand ImportPortfolio { get; set; }

		private void OnImportPortfolio()
		{
			var item = PortfolioImportService.Import("Enter you ssn", 2);
			this.db.Portfolios.Add(item);
			Content = new PortfolioViewModel(this.db, item);
		}
	}
}
