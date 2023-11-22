using DinkToPdf;
using DinkToPdf.Contracts;

namespace DinkToPDFNetCore.Service
{
    public class DocumentService : IDocumentService
    {
        private GlobalSettings globalSettings;
        private ObjectSettings objectSettings;
        private WebSettings webSettings;
        private HeaderSettings headerSettings;
        private FooterSettings footerSettings;
        private readonly IConverter _converter;

        public DocumentService(IConverter converter)
        {
            objectSettings = new ObjectSettings();
            webSettings = new WebSettings();
            headerSettings = new HeaderSettings();
            footerSettings = new FooterSettings();
            globalSettings = new GlobalSettings();
            _converter = converter;
        }

        public async Task<byte[]> GeneratePdfReport(string template)
        {
            byte[] result;
            HtmlToPdfDocument htmlToPdfDocument;

            htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = GetGlobalSettings(),
                Objects = { GetObjectSettings(template) }
            };

            result = await Task.FromResult(_converter.Convert(htmlToPdfDocument));

            return result;
        }

        private GlobalSettings GetGlobalSettings()
        {
            globalSettings.ColorMode = ColorMode.Color;
            globalSettings.Orientation = Orientation.Portrait;
            globalSettings.PaperSize = PaperKind.Letter;
            globalSettings.Margins = new MarginSettings { Top = 1, Bottom = 1, Left = .5, Right = .5, Unit = Unit.Inches };

            return globalSettings;
        }

        private WebSettings WebSettings()
        {
            webSettings.DefaultEncoding = "UTF-8";
            return webSettings;
        }

        private ObjectSettings GetObjectSettings(string template)
        {
            objectSettings.PagesCount = true;
            objectSettings.WebSettings = WebSettings();
            objectSettings.HtmlContent = template;
            objectSettings.HeaderSettings = HeaderSettings();
            objectSettings.FooterSettings = FooterSettings();

            return objectSettings;
        }

        private HeaderSettings HeaderSettings()
        {
            headerSettings.FontSize = 6;
            headerSettings.FontName = "Times New Roman";//"Arial Narrow";
            headerSettings.Right = "Page [page] of [toPage]";
            headerSettings.Left = "XYZ Company Inc.";
            headerSettings.Line = true;

            return headerSettings;
        }

        private FooterSettings FooterSettings()
        {
            footerSettings.FontSize = 5;
            footerSettings.FontName = "Times New Roman";//"Arial Narrow";
            footerSettings.Center = "Revision As Of August 2021";
            footerSettings.Line = true;
            return footerSettings;
        }
    }
}
