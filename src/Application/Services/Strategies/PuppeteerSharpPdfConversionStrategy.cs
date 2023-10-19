using Application.Models;
using Application.Services.Interface;
using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace Application.Services.Strategies
{
    public class PuppeteerSharpPdfConversionStrategy : IPdfConversionStrategy
    {
        private const string template =
            "<div style='font-size: 9px; text-align: right;'>Page <span class='pageNumber'></span> of <span class='totalPages'></span></div>";

        public PuppeteerSharpPdfConversionStrategy() { }

        public PdfItem GeneratePdfFromHtml(string htmlValue)
        {
            using var browser = Puppeteer.LaunchAsync(new LaunchOptions { Headless = true }).Result;
            using var page = browser.NewPageAsync().Result;
            page.SetContentAsync(htmlValue).Wait();
            var pdfOptions = new PdfOptions
            {
                HeaderTemplate = template,
                FooterTemplate = template,
                DisplayHeaderFooter = true,
                PrintBackground = true,
                Format = PaperFormat.A4,
                MarginOptions = new MarginOptions
                {
                    Top = "1cm",
                    Bottom = "1cm",
                    Left = "1cm",
                    Right = "1cm"
                },
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
                HeaderTemplate = template,
                FooterTemplate = template,
                DisplayHeaderFooter = true,
                PrintBackground = true,
                Format = PaperFormat.A4,
                MarginOptions = new MarginOptions
                {
                    Top = "1cm",
                    Bottom = "1cm",
                    Left = "1cm",
                    Right = "1cm"
                },
            };
            byte[] pdfBytes = await page.PdfDataAsync(pdfOptions);
            return new PdfItem(pdfBytes);
        }
    }
}
