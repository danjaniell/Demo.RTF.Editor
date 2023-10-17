using Application.Models;

namespace Application.Services.Interface;

public interface IPdfConverter
{
    PdfItem GeneratePdfFromHtml(string htmlValue);
    Task<PdfItem> GeneratePdfFromHtmlAsync(string htmlValue);
}
