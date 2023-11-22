namespace DinkToPDFNetCore.Service
{
    public class ReportService : IReportService
    {
        public IDocumentService DocumentService { get; private set; }

        public ReportService(IDocumentService documentService)
        {
            DocumentService = documentService;
        }
    }
}
