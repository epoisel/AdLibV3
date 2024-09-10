using AutomationPlatform.Core;
using AutomationPlatform.PluginContracts;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace AutomationPlatform.UI.ViewModels
{ 
public class MainViewModel : ReactiveObject
{
    public ObservableCollection<IAutomationPlugin> Plugins { get; }
    public ReactiveCommand<IAutomationPlugin, Unit> ExecutePluginCommand { get; }
    public ReactiveCommand<IAutomationPlugin, Unit> ConfigurePluginCommand { get; }

    public MainViewModel(PluginLoader pluginLoader)
    {
        // Declare the path to the plugins here
        var pluginPath = @"C:\Users\epois\Documents\AdLib-2\AutomationPlatform\AutomationPlatform.Core\Plugins\";  // Replace with actual path

        // Load the plugins
        var loadedPlugins = pluginLoader.LoadPlugins(pluginPath);

        // Initialize the ObservableCollection with the loaded plugins
        Plugins = new ObservableCollection<IAutomationPlugin>(loadedPlugins);

        // Commands for the plugins
        ExecutePluginCommand = ReactiveCommand.Create<IAutomationPlugin>(plugin =>
        {
            plugin.Execute();
        });

        ConfigurePluginCommand = ReactiveCommand.Create<IAutomationPlugin>(plugin =>
        {
            plugin.Configure();
        });
    }
}
}