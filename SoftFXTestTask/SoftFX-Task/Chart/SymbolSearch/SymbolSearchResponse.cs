using Newtonsoft.Json;

namespace SoftFXTestTask.Chart_Files
{
    public class SymbolSearchResponse
    {
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "full_name")]
        public string SymbolFullName { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "exchange")]
        public string Exchange { get; set; }
        [JsonProperty(PropertyName = "ticker")]
        public string Ticker { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        public SymbolSearchResponse()
        {
            Description = string.Empty;
            Exchange = string.Empty;
            Ticker = string.Empty;
            Type = "index";
        }
}
}