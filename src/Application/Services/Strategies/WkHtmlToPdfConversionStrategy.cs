using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;
using Application.Services.Interface;
using Application.Models;

namespace Application.Services.Strategies
{
    public class WkHtmlToPdfConversionStrategy : IPdfConversionStrategy
    {
        private readonly IConverter _converter;

        public WkHtmlToPdfConversionStrategy(IConverter converter)
        {
            _converter = converter;
        }

        public PdfItem GeneratePdfFromHtml(string htmlValue)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HtmlContent = htmlValue,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings =
                        {
                            FontSize = 9,
                            Right = "Page [page] of [toPage]",
                            Line = true,
                            Spacing = 2.812
                        }
                    }
                }
            };

            byte[] pdfBytes = _converter.Convert(doc);

            return new PdfItem(pdfBytes);
        }

        public async Task<PdfItem> GeneratePdfFromHtmlAsync(string htmlValue)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HtmlContent = htmlValue,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings =
                        {
                            FontSize = 9,
                            Right = "Page [page] of [toPage]",
                            Line = true,
                            Spacing = 2.812
                        }
                    }
                }
            };

            byte[] pdfBytes = _converter.Convert(doc);

            return await Task.FromResult(new PdfItem(pdfBytes));
        }
    }
}
