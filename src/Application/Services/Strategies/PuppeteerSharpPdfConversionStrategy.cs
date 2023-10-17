using Application.Models;
using Application.Services.Interface;
using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace Application.Services.Strategies
{
    public class PuppeteerSharpPdfConversionStrategy : IPdfConversionStrategy
    {
        public PuppeteerSharpPdfConversionStrategy() { }

        public PdfItem GeneratePdfFromHtml(string htmlValue)
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
            return new PdfItem(pdfBytes);
        }

        public async Task<PdfItem> GeneratePdfFromHtmlAsync(string htmlValue)
        {
            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            using var page = await browser.NewPageAsync();
            await page.SetContentAsync(htmlValue);
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
            await page.PdfAsync(filePath, pdfOptions);
            byte[] pdfBytes = await File.ReadAllBytesAsync(filePath);
            File.Delete(filePath);
            return new PdfItem(pdfBytes);
        }
    }
}
