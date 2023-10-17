using Application.Models;
using Application.Services.Interface;
using Balbarak.WeasyPrint;

namespace Application.Services.Strategies
{
    public class WeasyPrintPdfConversionStrategy : IPdfConversionStrategy
    {
        public WeasyPrintPdfConversionStrategy() { }

        public PdfItem GeneratePdfFromHtml(string htmlValue)
        {
            using WeasyPrintClient client = new();
            var pdfBytes = client.GeneratePdf(htmlValue);
            return new PdfItem(pdfBytes);
        }

        public async Task<PdfItem> GeneratePdfFromHtmlAsync(string htmlValue)
        {
            using WeasyPrintClient client = new();
            var pdfBytes = await client.GeneratePdfAsync(htmlValue);
            return new PdfItem(pdfBytes);
        }
    }
}
