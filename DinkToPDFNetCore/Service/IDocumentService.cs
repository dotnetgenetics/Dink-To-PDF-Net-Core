namespace DinkToPDFNetCore.Service
{
    public interface IDocumentService
    {
        Task<byte[]> GeneratePdfReport(string template);
    }
}
