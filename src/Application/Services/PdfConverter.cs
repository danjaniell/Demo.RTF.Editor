using Application.Services.Interface;

namespace Application.Services
{
    public class PdfConverter<T>
        where T : IPdfConversionStrategy
    {
        private readonly IServiceProvider _serviceProvider;

        public PdfConverter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public string GeneratePdfFromHtml(string htmlValue)
        {
            var specificStrategy = _serviceProvider.GetRequiredService<T>();
            return specificStrategy.GeneratePdfFromHtml(htmlValue);
        }
    }
}
