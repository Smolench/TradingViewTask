using System.Collections.Generic;
using static AutoMapper.Mapper;
using SoftFXTestTask.EntityFramework.EntityModels;
using Newtonsoft.Json;
using SoftFXTestTask.Chart;

namespace SoftFXTestTask.Controllers
{
    public class HistoryController : ApiBase
    {
        public string Get(string symbol, long from, long to, string resolution)
        {
            var bars = Map<ICollection<Quote>, Bars>(QuoteRepository.GetList(x => x.Symbol.Name.ToUpper() == symbol && x.DateTime >= from && x.DateTime <= to));
            return JsonConvert.SerializeObject(bars);
        }
    }
}