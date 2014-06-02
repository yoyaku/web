using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Raven.Client;
using Raven.Client.Embedded;

namespace web.Controllers
{
    public abstract class RavenDbController : ApiController
    {
        public IDocumentStore Store
        {
            get { return LazyDocStore.Value; }
        }

        private static readonly Lazy<IDocumentStore> LazyDocStore = new Lazy<IDocumentStore>(() =>
        {
            var documentStore = new EmbeddableDocumentStore
            {
                DataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString(),
                UseEmbeddedHttpServer = true
            };
            documentStore.Initialize();
            return documentStore;
        });

        public IAsyncDocumentSession Session { get; set; }

        public async override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            using (Session = Store.OpenAsyncSession())
            {
                var result = await base.ExecuteAsync(controllerContext, cancellationToken);
                await Session.SaveChangesAsync();
                return result;
            }
        }
    }
}
