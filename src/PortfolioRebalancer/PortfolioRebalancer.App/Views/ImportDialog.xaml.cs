using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace PortfolioRebalancer.App.Views
{
    public class ImportDialog : Window
    {
        public ImportDialog()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void OnButtonClick(object sender, RoutedEventArgs e)
        {
            //do something on click
            Close("OK Clicked!");
        }
    }
}
