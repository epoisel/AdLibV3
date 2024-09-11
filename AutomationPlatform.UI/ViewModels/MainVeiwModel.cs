using ReactiveUI;
using AutomationPlatform.Core;
using AutomationPlatform.PluginContracts;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AutomationPlatform.UI.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        // Collection of plugins loaded by the PluginLoader (Toolbox)
        public ObservableCollection<IAutomationPlugin> Plugins { get; }

        // Collection of plugins in the Workspace
        public ObservableCollection<IAutomationPlugin> WorkspacePlugins { get; }

        public ICommand RunPluginCommand { get; }

        // The selected plugin from the Toolbox
        private IAutomationPlugin? _selectedPlugin;
        public IAutomationPlugin? SelectedPlugin
        {
            get => _selectedPlugin;
            set => this.RaiseAndSetIfChanged(ref _selectedPlugin, value);
        }

        // The selected plugin from the Workspace
        private IAutomationPlugin? _selectedWorkspacePlugin;
        public IAutomationPlugin? SelectedWorkspacePlugin
        {
            get => _selectedWorkspacePlugin;
            set => this.RaiseAndSetIfChanged(ref _selectedWorkspacePlugin, value);
        }

        // This will hold the dynamically loaded UI for the plugin
        private object? _pluginUI;
        public object? PluginUI
        {
            get => _pluginUI;
            private set => this.RaiseAndSetIfChanged(ref _pluginUI, value);
        }

        // Constructor
        public MainViewModel(PluginLoader pluginLoader)
        {
            Plugins = new ObservableCollection<IAutomationPlugin>(pluginLoader.LoadPlugins(@"C:\Users\epois\Documents\AdLib-2\AutomationPlatform\AutomationPlatform.Core\Plugins\"));
            WorkspacePlugins = new ObservableCollection<IAutomationPlugin>();
        }

        // Add a plugin from the Toolbox to the Workspace
        public void AddPluginToWorkspace(IAutomationPlugin plugin)
        {
            WorkspacePlugins.Add(plugin);
        }

        // Remove a plugin from the Workspace
        public void RemovePluginFromWorkspace(IAutomationPlugin plugin)
        {
            WorkspacePlugins.Remove(plugin);
        }

        // Configure the selected plugin in the Workspace and load its UI if it has one
        public void ConfigurePlugin(IAutomationPlugin plugin)
        {
            plugin.Configure();

            if (plugin is IAutomationPluginWithUI pluginWithUI)
            {
                PluginUI = pluginWithUI.GetPluginUI();
            }
            else
            {
                PluginUI = null; // Clear the UI if the plugin doesn't have one
            }

        }
        public void RunPlugin(IAutomationPlugin plugin)
        {
            plugin.Execute();
        }
    }
}
