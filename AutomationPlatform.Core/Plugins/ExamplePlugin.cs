using AutomationPlatform.PluginContracts;

namespace AutomationPlatform.Core.Plugins
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
