namespace Application.Services.Interface
{
    public interface IPdfConversionStrategy
    {
        string GeneratePdfFromHtml(string htmlValue);
        Task<string> GeneratePdfFromHtmlAsync(string htmlValue);
    }
}
