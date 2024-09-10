using AutomationPlatform.PluginContracts;

namespace Plugins.Plugins
{
    public class ExamplePlugin : IAutomationPlugin
    {
        public string Name => "Example Plugin";

        public void Execute()
        {
            // Plugin logic for execution
            Console.WriteLine("Plugin Executed");
        }

        public void Configure()
        {
            // Plugin configuration logic
            Console.WriteLine("Plugin Configured");
        }
    }
}
