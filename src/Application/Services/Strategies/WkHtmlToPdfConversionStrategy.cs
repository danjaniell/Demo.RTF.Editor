using System;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;
using Application.Services.Interface;

namespace Application.Services.Strategies
{
    public class WkHtmlToPdfConversionStrategy : IPdfConversionStrategy
    {
        private readonly IConverter _converter;

        public WkHtmlToPdfConversionStrategy(IConverter converter)
        {
            _converter = converter;
        }

        public string GeneratePdfFromHtml(string htmlValue)
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

            return $"data:application/pdf;base64,{Convert.ToBase64String(pdfBytes)}";
        }
    }
}
