using Application.Services.Interface;
using Balbarak.WeasyPrint;

namespace Application.Services.Strategies
{
    public class WeasyPrintPdfConversionStrategy : IPdfConversionStrategy
    {
        public WeasyPrintPdfConversionStrategy() { }

        public string GeneratePdfFromHtml(string htmlValue)
        {
            using WeasyPrintClient client = new();
            var pdfBytes = client.GeneratePdf(htmlValue);
            return $"data:application/pdf;base64,{Convert.ToBase64String(pdfBytes)}";
        }
    }
}
