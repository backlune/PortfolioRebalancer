using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PortfolioRebalancer.App.Views
{
    public class PortfolioView : UserControl
    {
        public PortfolioView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
