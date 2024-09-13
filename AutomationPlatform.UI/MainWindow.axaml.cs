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

        // Event handler for adding a plugin to the workspace
        private void OnAddToWorkspaceClick(object sender, RoutedEventArgs e)
        {
            // Get the plugin from the CommandParameter
            var button = (Button)sender;
            if (button.CommandParameter is IAutomationPlugin plugin)
            {
                var viewModel = (MainViewModel)DataContext;
                viewModel.AddPluginToWorkspace(plugin);
            }
        }

        // Event handler for configuring a plugin in the workspace
        private void OnConfigureWorkspacePluginClick(object sender, RoutedEventArgs e)
        {
            // Get the plugin from the CommandParameter
            var button = (Button)sender;
            if (button.CommandParameter is IAutomationPlugin plugin)
            {
                var viewModel = (MainViewModel)DataContext;
                viewModel.ConfigurePlugin(plugin);
            }
        }

        // Event handler for removing a plugin from the workspace
        private void OnRemoveFromWorkspaceClick(object sender, RoutedEventArgs e)
        {
            // Get the plugin from the CommandParameter
            var button = (Button)sender;
            if (button.CommandParameter is IAutomationPlugin plugin)
            {
                var viewModel = (MainViewModel)DataContext;
                viewModel.RemovePluginFromWorkspace(plugin);
            }
        }

        // Event handler for running all plugins in the workspace
        private void OnRunWorkspacePluginClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            foreach (var plugin in viewModel.WorkspacePlugins)
            {
                viewModel.RunPlugin(plugin);
            }
        }
    }
}
