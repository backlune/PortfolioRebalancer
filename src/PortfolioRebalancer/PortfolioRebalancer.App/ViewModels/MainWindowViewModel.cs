﻿using PortfolioRebalancer.App.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PortfolioRebalancer.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
		private readonly Database _db;
		public MainWindowViewModel(Database db)
		{
			_db = db;
			ImportPortfolio = ReactiveCommand.Create(OnImportPortfolio);
		}

        public string Greeting => "Welcome to PortfolioRebalancer";

		private ViewModelBase _content;
		public ViewModelBase Content
		{
			get => _content;
			private set => this.RaiseAndSetIfChanged(ref _content, value);
		}

		public ICommand ImportPortfolio { get; set; }
		private void OnImportPortfolio()
		{
			Portfolio item = new Portfolio
			{
				Id = "2",
				Assets = new List<PortfolioAsset>
				{
					new PortfolioAsset{ Name = "Gold (USD)", Units = 15, UnitPrice = 10, ValueDomesticCurrency = 1500},
					new PortfolioAsset{ Name = "OMXS30", Units = 15, UnitPrice = 100, ValueDomesticCurrency = 1500},
					new PortfolioAsset{ Name = "Euro Gov Bond 15-25 yrs", Units = 10, UnitPrice = 20, ValueDomesticCurrency = 2000},
				}
			};
			_db.Portfolios.Add(item);

			Content = new PortfolioViewModel(_db, item);
		}

	}
}
