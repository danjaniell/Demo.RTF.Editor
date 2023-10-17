using Application.Services.Interface;
using PhantomJs.NetCore;

namespace Application.Services.Strategies
{
    public class PhantomJsPdfConversionStrategy : IPdfConversionStrategy
    {
        public PhantomJsPdfConversionStrategy() { }

        public string GeneratePdfFromHtml(string htmlValue)
        {
            var generator = new PdfGenerator();
            var originalPath = generator.GeneratePdf(htmlValue, Environment.CurrentDirectory);
            byte[] pdfBytes = File.ReadAllBytes(originalPath);
            File.Delete(originalPath);
            return $"data:application/pdf;base64,{Convert.ToBase64String(pdfBytes)}";
        }

        public async Task<string> GeneratePdfFromHtmlAsync(string htmlValue)
        {
            var generator = new PdfGenerator();
            var originalPath = generator.GeneratePdf(htmlValue, Environment.CurrentDirectory);
            byte[] pdfBytes = await File.ReadAllBytesAsync(originalPath);
            File.Delete(originalPath);
            return $"data:application/pdf;base64,{Convert.ToBase64String(pdfBytes)}";
        }
    }
}
