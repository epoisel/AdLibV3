using ReactiveUI;
using AutomationPlatform.Core;
using AutomationPlatform.PluginContracts;
using System.Collections.ObjectModel;

namespace AutomationPlatform.UI.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        // Collection of plugins loaded by the PluginLoader
        public ObservableCollection<IAutomationPlugin> Plugins { get; }

        // The selected plugin from the ListBox
        private IAutomationPlugin? _selectedPlugin;
        public IAutomationPlugin? SelectedPlugin
        {
            get => _selectedPlugin;
            set => this.RaiseAndSetIfChanged(ref _selectedPlugin, value);
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
        }

        // Method to configure the plugin and load its UI if it has one
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
    }
}
