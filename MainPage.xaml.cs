using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace WEBVIEW
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Sample transaction data
            var transactions = new List<Transaction>
            {
                new Transaction { Date = "2024-08-05", Description = "Deposit", Amount = 5000 },
                new Transaction { Date = "2024-08-06", Description = "Withdrawal", Amount = 2000 },
                new Transaction { Date = "2024-08-07", Description = "Transfer", Amount = 1500 },
                new Transaction { Date = "2024-08-09", Description = "Transfer", Amount = 11500 }
            };

            // Generate HTML content
            string htmlContent = GenerateHtml(transactions);

            // Load HTML content into the WebView
            TransactionWebView.Source = new HtmlWebViewSource { Html = htmlContent };
        }

        private string GenerateHtml(List<Transaction> transactions)
        {
            // Read the HTML template from the embedded resource
            string htmlTemplate = ReadHtmlTemplate("WEBVIEW.transaction.html");

            // Replace the placeholder with transaction data
            var rows = new StringBuilder();
            foreach (var transaction in transactions)
            {
                rows.Append($"<tr><td>{transaction.Date}</td><td>{transaction.Description}</td><td>{transaction.Amount:C}</td></tr>");
            }

            // Replace the placeholder in the template with actual rows
            htmlTemplate = htmlTemplate.Replace("<!-- Transaction rows will be inserted here -->", rows.ToString());

            return htmlTemplate;
        }

        private string ReadHtmlTemplate(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    public class Transaction
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
