using Application.Services.Interface;
using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace Application.Services.Strategies
{
    public class PuppeteerSharpPdfConversionStrategy : IPdfConversionStrategy
    {
        public PuppeteerSharpPdfConversionStrategy() { }

        public string GeneratePdfFromHtml(string htmlValue)
        {
            using var browser = Puppeteer.LaunchAsync(new LaunchOptions { Headless = true }).Result;
            using var page = browser.NewPageAsync().Result;
            page.SetContentAsync(htmlValue).Wait();
            var pdfOptions = new PdfOptions
            {
                DisplayHeaderFooter = true,
                Landscape = true,
                PrintBackground = true,
                Format = PaperFormat.A4,
                MarginOptions = new MarginOptions
                {
                    Top = "1cm",
                    Bottom = "1cm",
                    Left = "1cm",
                    Right = "1cm"
                },
                Scale = 1.5m,
            };
            string filePath = $"{Environment.CurrentDirectory}\\{Guid.NewGuid()}.pdf";
            page.PdfAsync(filePath, pdfOptions).Wait();
            byte[] pdfBytes = File.ReadAllBytes(filePath);
            File.Delete(filePath);
            return $"data:application/pdf;base64,{Convert.ToBase64String(pdfBytes)}";
        }
    }
}
