using Application.Models;
using Application.Services.Interface;
using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace Application.Services.Strategies
{
    public class PuppeteerSharpPdfConversionStrategy : IPdfConversionStrategy
    {
        private const string template = "<div style='font-size: 9px; text-align: right;'></div>";

        public PuppeteerSharpPdfConversionStrategy() { }

        public PdfItem GeneratePdfFromHtml(string htmlValue)
        {
            using var browser = Puppeteer.LaunchAsync(new LaunchOptions { Headless = true }).Result;
            using var page = browser.NewPageAsync().Result;
            page.SetContentAsync(htmlValue).Wait();
            var pdfOptions = new PdfOptions
            {
                PrintBackground = true,
                Format = PaperFormat.A4,
                MarginOptions = new MarginOptions
                {
                    Top = "5mm",
                    Bottom = "1mm",
                    Left = "5mm",
                    Right = "5mm",
                },
                Scale = 1.2m
            };
            byte[] pdfBytes = page.PdfDataAsync(pdfOptions).Result;
            return new PdfItem(pdfBytes);
        }

        public async Task<PdfItem> GeneratePdfFromHtmlAsync(string htmlValue)
        {
            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            using var page = await browser.NewPageAsync();
            await page.SetContentAsync(htmlValue);
            var pdfOptions = new PdfOptions
            {
                PrintBackground = true,
                Format = PaperFormat.A4,
                MarginOptions = new MarginOptions
                {
                    Top = "5mm",
                    Bottom = "1mm",
                    Left = "5mm",
                    Right = "5mm",
                },
                Scale = 1.2m
            };
            byte[] pdfBytes = await page.PdfDataAsync(pdfOptions);
            return new PdfItem(pdfBytes);
        }
    }
}
