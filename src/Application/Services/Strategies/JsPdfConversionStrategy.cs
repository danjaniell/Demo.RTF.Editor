using Application.Models;
using Application.Services.Interface;
using Microsoft.JSInterop;

namespace Application.Services.Strategies
{
    public class JsPdfConversionStrategy : IPdfConversionStrategy
    {
        private readonly IJSRuntime JSRuntime;

        public JsPdfConversionStrategy(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }

        public PdfItem GeneratePdfFromHtml(string htmlValue)
        {
            return new PdfItem(
                JSRuntime.InvokeAsync<byte[]>("JsPdfFunctions.generatePdf", htmlValue).Result
            );
        }

        public async Task<PdfItem> GeneratePdfFromHtmlAsync(string htmlValue)
        {
            return new PdfItem(
                await JSRuntime.InvokeAsync<byte[]>("JsPdfFunctions.generatePdf", htmlValue)
            );
        }
    }
}
