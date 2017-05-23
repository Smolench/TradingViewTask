using System;
using Newtonsoft.Json;
using SoftFXTestTask.Chart_Files;
using SoftFXTestTask.EntityFramework;
using SoftFXTestTask.EntityFramework.EntityModels;
using static AutoMapper.Mapper;

namespace SoftFXTestTask.Controllers
{
    public class SymbolsController : ApiBase
    {
        public string Get(string symbol)
        {
            int index = symbol.IndexOf(":", StringComparison.Ordinal);
            if (index > 0)
            {
                symbol = symbol.Substring(0, index);
            }
            var symbolModel = Map<Symbol, SymbolInfo>(SymbolRepository.Get(x => x.Name.ToUpper() == symbol));
            
            //Change price resolution
            if(CustomDatas.GetIntegerSymbolsName().Contains(symbolModel.Name.ToUpper()))
            {
                symbolModel.MinMov = 1;
                symbolModel.PriceScale = 1;
            }
            return JsonConvert.SerializeObject(symbolModel);
        }
    }
}