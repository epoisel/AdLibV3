using Avalonia.Controls;
using Avalonia.Interactivity;
using AutomationPlatform.PluginContracts;
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
            DataContext = new MainViewModel(new PluginLoader());
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        // Event handler for running the plugin
        private void OnRunPluginClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            if (viewModel.SelectedPlugin != null)
            {
                viewModel.SelectedPlugin.Execute();
            }
        }

        // Event handler for configuring the plugin
        private void OnConfigurePluginClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            if (viewModel.SelectedPlugin != null)
            {
                viewModel.ConfigurePlugin(viewModel.SelectedPlugin);
            }
        }
    }
}
