using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace OpenApplication
{
    public partial class OpenAppPluginUI : UserControl
    {
        private TextBox _filePathTextBox;
        private OpenAppPlugin _plugin;  // Reference to the plugin

        public OpenAppPluginUI(OpenAppPlugin plugin)  // Pass the plugin in the constructor
        {
            _plugin = plugin;  // Store the reference to the plugin
            InitializeComponent();
            _filePathTextBox = this.FindControl<TextBox>("FilePathTextBox");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        // Handle browse button click
        private async void OnBrowseClick(object? sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                AllowMultiple = false,
                Filters = new List<FileDialogFilter>
                {
                    new FileDialogFilter { Name = "Applications", Extensions = { "exe" } }
                }
            };

            var result = await openFileDialog.ShowAsync((Window)this.VisualRoot);
            if (result != null && result.Length > 0)
            {
                _filePathTextBox.Text = result[0];  // Set the selected file path in the TextBox
                _plugin.SetAppPath(result[0]);  // Set the selected file path in the plugin
            }
        }
    }
}
