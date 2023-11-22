
using DinkToPdf;
using DinkToPdf.Contracts;
using DinkToPDFNetCore.Service;
using Unity;

namespace DinkToPDFNetCore.Helpers
{
    public class UnityContainerResolver
    {
        private UnityContainer container;

        public UnityContainerResolver()
        {
            container = new UnityContainer();
            RegisterTypes();
        }

        public void RegisterTypes()
        {
            container.RegisterType<IDocumentService, DocumentService>();
            container.RegisterInstance(typeof(IConverter), new STASynchronizedConverter(new PdfTools()), InstanceLifetime.Singleton);
            container.RegisterType<IReportService, ReportService>();
        }

        public ReportService Resolver()
        {
            return container.Resolve<ReportService>();
        }
    }
}
