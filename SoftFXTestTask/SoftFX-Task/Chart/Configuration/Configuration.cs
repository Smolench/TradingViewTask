using Newtonsoft.Json;
using System.Collections.Generic;

namespace SoftFXTestTask.Chart
{
    public class Configuration
    {
        [JsonProperty(PropertyName = "supports_search")]
        public bool IsSupportSearch { get; set; }
        [JsonProperty(PropertyName = "exchanges")]
        public ICollection<Exchanges> Exchanges { get; set; }
        [JsonProperty(PropertyName = "symbols_types")]
        public ICollection<SymbolTypes> SymbolsTypes { get; set; }
        [JsonProperty(PropertyName = "supported_resolutions")]
        public ICollection<string> SupportedResolutions { get; set; }
        [JsonProperty(PropertyName = "supports_marks")]
        public bool IsSupportsMarks { get; set; }
        [JsonProperty(PropertyName = "supports_timescale_marks")]
        public bool IsSupportsTimescaleMarks { get; set; }
        [JsonProperty(PropertyName = "supports_time")]
        public bool IsSupportsTime { get; set; }
        public Configuration()
        {
            IsSupportSearch = true;
            IsSupportsMarks = false;
            IsSupportsTimescaleMarks = false;
            IsSupportsTime = true;
            SupportedResolutions = new List<string>() {"60", "120", "D" };
            SymbolsTypes = new List<SymbolTypes>() { new SymbolTypes() { Name="All types", Value = ""}, new SymbolTypes() { Name = "Index", Value = "indexs"} };
            Exchanges = new List<Exchanges>() { new Exchanges() { Value = "", Name = "All Exchanges", Desc = "" } };
        }

    }
    public class Exchanges
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "desc")]
        public string Desc { get; set; }
    }
    public class SymbolTypes
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }

}