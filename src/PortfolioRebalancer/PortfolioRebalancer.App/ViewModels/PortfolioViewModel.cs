using PortfolioRebalancer.App.Services;
using System;
using System.Collections.Generic;

namespace PortfolioRebalancer.App.ViewModels
{
	public class PortfolioViewModel : ViewModelBase
	{
		private Database db;
		private Portfolio Portfolio;

		public PortfolioViewModel(Database db, Portfolio item)
		{
			this.db = db;
			this.Portfolio = item;
		}

		public string Id
		{
			get => this.Portfolio.Id;
			set
			{
				if (this.Portfolio.Id == value)
				{
					return;
				}

				this.Portfolio.Id = value;
			}
		}

		public List<PortfolioAsset> Assets
		{
			get => this.Portfolio.Assets;
			set
			{
				if (this.Portfolio.Assets == value)
				{
					return;
				}

				this.Portfolio.Assets = value;
			}
		}
	}
}
