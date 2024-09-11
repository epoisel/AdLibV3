namespace AutomationPlatform.PluginContracts
{
    public interface IConfigurablePlugin : IAutomationPlugin
    {
        string ApplicationPath { get; set; }
    }
}
