using SoftFXTestTask.Services.Repositories;
using System.Web.Http;

namespace SoftFXTestTask.Controllers
{
    public class ApiBase : ApiController
    {
        protected readonly SymbolsRepository SymbolRepository = new SymbolsRepository();
        protected readonly QuotesRepository QuoteRepository = new QuotesRepository();
    }
}