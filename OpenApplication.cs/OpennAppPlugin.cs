using AutomationPlatform.PluginContracts;
using System.Diagnostics;

namespace AutomationPlatform.Core.Plugins
{
    public class OpenAppPlugin : IAutomationPlugin
    {
        public string Name => "Open Application Plugin";
        private string? _appPath;

        // Method for setting the app path externally (UI will handle file browsing)
        public void SetAppPath(string appPath)
        {
            _appPath = appPath;
        }

        public void Execute()
        {
            // Launch the selected application
            if (!string.IsNullOrEmpty(_appPath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = _appPath,
                    UseShellExecute = true
                });
            }
            else
            {
                Debug.WriteLine("No application selected.");
            }
        }

        public void Configure()
        {
            // Nothing happens here, configuration is handled by the UI
        }
    }
}
