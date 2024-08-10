using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Reflection;

namespace WEBVIEW
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var htmlSource = new HtmlWebViewSource
            {
                Html = LoadHtmlContent()
            };

            ReceiptWebView.Source = htmlSource;
        }

        private string LoadHtmlContent()
        {
            try
            {
                // Use a relative path
                var filePath = Path.Combine(AppContext.BaseDirectory, "transaction.html");

                // Print the file path to the debug console
                System.Diagnostics.Debug.WriteLine($"Looking for file at: {filePath}");

                if (File.Exists(filePath))
                {
                    return File.ReadAllText(filePath);
                }
                else
                {
                    return "<html><body><h1>File not found</h1></body></html>";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions and print the error message
                System.Diagnostics.Debug.WriteLine($"Error loading file: {ex.Message}");
                return "<html><body><h1>Error loading file</h1></body></html>";
            }
        }
    }
}
