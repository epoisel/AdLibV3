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

        // Event handler for adding plugin to the workspace
        private void OnAddToWorkspaceClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            if (viewModel.SelectedPlugin != null)
            {
                viewModel.AddPluginToWorkspace(viewModel.SelectedPlugin);
            }
        }

        // Event handler for configuring plugin in the workspace
        private void OnConfigureWorkspacePluginClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            if (viewModel.SelectedWorkspacePlugin != null)
            {
                viewModel.ConfigurePlugin(viewModel.SelectedWorkspacePlugin);
            }
        }

        // Event handler for removing plugin from the workspace
        private void OnRemoveFromWorkspaceClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            if (viewModel.SelectedWorkspacePlugin != null)
            {
                viewModel.RemovePluginFromWorkspace(viewModel.SelectedWorkspacePlugin);
            }
        }

        // Event handler for running the selected plugin in the workspace
        private void OnRunWorkspacePluginClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            if (viewModel.SelectedWorkspacePlugin != null)
            {
                viewModel.RunPlugin(viewModel.SelectedWorkspacePlugin);
            }
        }
    }
}
