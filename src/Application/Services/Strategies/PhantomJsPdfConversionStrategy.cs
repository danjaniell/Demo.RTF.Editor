using Application.Models;
using Application.Services.Interface;
using PhantomJs.NetCore;

namespace Application.Services.Strategies
{
    public class PhantomJsPdfConversionStrategy : IPdfConversionStrategy
    {
        public PhantomJsPdfConversionStrategy() { }

        public PdfItem GeneratePdfFromHtml(string htmlValue)
        {
            var generator = new PdfGenerator();
            var originalPath = generator.GeneratePdf(htmlValue, Environment.CurrentDirectory);
            byte[] pdfBytes = File.ReadAllBytes(originalPath);
            File.Delete(originalPath);
            return new PdfItem(pdfBytes);
        }

        public async Task<PdfItem> GeneratePdfFromHtmlAsync(string htmlValue)
        {
            var generator = new PdfGenerator();
            var originalPath = generator.GeneratePdf(htmlValue, Environment.CurrentDirectory);
            byte[] pdfBytes = await File.ReadAllBytesAsync(originalPath);
            File.Delete(originalPath);
            return new PdfItem(pdfBytes);
        }
    }
}
