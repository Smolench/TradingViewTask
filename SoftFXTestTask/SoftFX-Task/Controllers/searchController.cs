using Newtonsoft.Json;
using SoftFXTestTask.Chart_Files;
using SoftFXTestTask.EntityFramework.EntityModels;
using System.Collections.Generic;
using static AutoMapper.Mapper;

namespace SoftFXTestTask.Controllers
{
    public class SearchController : ApiBase
    {
        public string Get(string query, string type, string exchange, int limit)
        {
            var data = SymbolRepository.GetList(x => x.Name.ToUpper().Contains(query));
            return JsonConvert.SerializeObject(data != null ? Map<ICollection<Symbol>, ICollection<SymbolSearchResponse>>(data) : new List<SymbolSearchResponse>());
        }
    }
}