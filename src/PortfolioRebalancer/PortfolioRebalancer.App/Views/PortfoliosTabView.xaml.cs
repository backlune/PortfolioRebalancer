using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PortfolioRebalancer.App.Views
{
    public class PortfoliosTabView : UserControl
    {
        public PortfoliosTabView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
