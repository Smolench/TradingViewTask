using AutoMapper;
using SoftFXTestTask.Chart_Files;
using SoftFXTestTask.EntityFramework.EntityModels;
using System.Collections.Generic;
using System.Linq;
using SoftFXTestTask.Chart;

namespace SoftFXTestTask.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ICollection<Quote>, Bars>()
                .ForMember(x => x.DateTime, c => c.MapFrom(v => v.Select(b => b.DateTime).ToList()))
                .ForMember(x => x.Close, c => c.MapFrom(v => v.Select(b => b.Close).ToList()))
                .ForMember(x => x.Open, c => c.MapFrom(v => v.Select(b => b.Open).ToList()))
                .ForMember(x => x.High, c => c.MapFrom(v => v.Select(b => b.High).ToList()))
                .ForMember(x => x.Low, c => c.MapFrom(v => v.Select(b => b.Low).ToList()))
                .ForMember(x => x.Volume, c => c.MapFrom(v => v.Select(b => b.Volume).ToList()));
            CreateMap<Symbol, SymbolSearchResponse>()
                .ForMember(x => x.Symbol, c => c.MapFrom(v => v.Name))
                .ForMember(x => x.SymbolFullName, c => c.MapFrom(v => v.Name + ":" + v.Name))
                .ForMember(x => x.Ticker, c => c.MapFrom(v => v.Name))
                .ForAllOtherMembers(x => x.Ignore());
            CreateMap<Symbol, SymbolInfo>()
                .ForMember(x => x.Name, c => c.MapFrom(v => v.Name))
                .ForMember(x => x.Ticker, c => c.MapFrom(v => v.Name))
                .ForMember(x => x.Exchange, c => c.MapFrom(v => v.Name))
                .ForMember(x => x.ListedExchange, c => c.MapFrom(v => v.Name));
        }
    }
}