using Avalonia.Controls;
using AutomationPlatform.UI.ViewModels;
using AutomationPlatform.Core;
using Avalonia.Markup.Xaml;

namespace AutomationPlatform.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Ensure DataContext is set correctly here
            var pluginLoader = new PluginLoader();
            var viewModel = new MainViewModel(pluginLoader);
            DataContext = viewModel;  // Explicitly set the ViewModel here
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);  // This ensures the XAML is loaded
        }
    }
}
