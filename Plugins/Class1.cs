using AutomationPlatform.PluginContracts;
using System;

namespace Plugins
{
    public class MyPlugin : IAutomationPlugin
    {
        public string Name => "My Example Plugin";

        public void Execute()
        {
            Console.WriteLine("Plugin Executed");
        }

        public void Configure()
        {
            Console.WriteLine("Plugin Configured");
        }
    }
}
