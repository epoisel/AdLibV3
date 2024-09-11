namespace AutomationPlatform.PluginContracts
{
    public interface IAutomationPluginWithUI : IAutomationPlugin
    {
        object GetPluginUI();
    }
}
