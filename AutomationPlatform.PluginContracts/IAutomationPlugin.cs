namespace AutomationPlatform.PluginContracts
{
    public interface IAutomationPlugin
    {
        string Name { get; }

        void Execute();
        void Configure();
    }
}
