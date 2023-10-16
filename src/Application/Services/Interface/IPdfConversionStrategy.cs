namespace Application.Services.Interface
{
    public interface IPdfConversionStrategy
    {
        string GeneratePdfFromHtml(string htmlValue);
    }
}
