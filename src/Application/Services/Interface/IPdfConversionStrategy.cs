using Application.Models;

namespace Application.Services.Interface
{
    public interface IPdfConversionStrategy
    {
        PdfItem GeneratePdfFromHtml(string htmlValue);
        Task<PdfItem> GeneratePdfFromHtmlAsync(string htmlValue);
    }
}
