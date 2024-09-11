using AutomationPlatform.PluginContracts;
using System.Reflection;

namespace AutomationPlatform.Core
{
    public class PluginLoader
    {
        public PluginLoader() { }

        public IEnumerable<IAutomationPlugin> LoadPlugins(string path)
        {
            var plugins = new List<IAutomationPlugin>();

            if (!Directory.Exists(path))
                return plugins;

            var dlls = Directory.GetFiles(path, "*.dll");
            foreach (var dll in dlls)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var types = assembly.GetTypes()
                        .Where(t => typeof(IAutomationPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                    foreach (var type in types)
                    {
                        if (Activator.CreateInstance(type) is IAutomationPlugin plugin)
                        {
                            plugins.Add(plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading plugins from {dll}: {ex.Message}");
                }
            }

            return plugins;
        }

        // Additional method to load and return UIs
        public object? GetPluginUI(IAutomationPlugin plugin)
        {
            if (plugin is IAutomationPluginWithUI pluginWithUI)
            {
                return pluginWithUI.GetPluginUI();
            }

            return null; // No UI for this plugin
        }
    }
}
