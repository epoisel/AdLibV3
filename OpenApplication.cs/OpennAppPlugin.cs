using AutomationPlatform.PluginContracts;
using System;
using System.Diagnostics;
using System.IO;

namespace OpenApplication
{
    public class OpenAppPlugin : IAutomationPluginWithUI
    {
        private string? _appPath;

        public string Name => "Open Application Plugin";

        // Set the application path
        public void SetAppPath(string appPath)
        {
            if (File.Exists(appPath) && Path.GetExtension(appPath).Equals(".exe", StringComparison.OrdinalIgnoreCase))
            {
                _appPath = appPath;
            }
            else
            {
                throw new ArgumentException("Invalid application path or the file is not an executable.");
            }
        }

        // Execute the plugin (run the selected application)
        public void Execute()
        {
            if (!string.IsNullOrEmpty(_appPath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = _appPath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error launching application: {ex.Message}");
                }
            }
            else
            {
                Debug.WriteLine("No application selected.");
            }
        }

        // Return the custom UI for configuring the plugin, passing the plugin instance to the UI
        public object GetPluginUI()
        {
            return new OpenAppPluginUI(this);  // Pass the plugin instance to the UI
        }

        public void Configure()
        {
            // Optional configuration logic
        }
    }
}
