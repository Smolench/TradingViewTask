using Newtonsoft.Json;
using System.Collections.Generic;

namespace SoftFXTestTask.Chart
{
    public class Bars
    {
        [JsonProperty(PropertyName = "s")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "errmsg")]
        public string ErrorMessage { get; set; }
        [JsonProperty(PropertyName = "t")]
        public ICollection<long> DateTime { get; set; }
        [JsonProperty(PropertyName = "c")]
        public ICollection<double> Close { get; set; }
        [JsonProperty(PropertyName = "o")]
        public ICollection<double> Open { get; set; }
        [JsonProperty(PropertyName = "h")]
        public ICollection<double> High { get; set; }
        [JsonProperty(PropertyName = "l")]
        public ICollection<double> Low { get; set; }
        [JsonProperty(PropertyName = "v")]
        public ICollection<int> Volume { get; set; }
        [JsonProperty(PropertyName = "nextTime")]
        public string NextTime { get; set; }
        public Bars()
        {
            Status = "ok";
            ErrorMessage = string.Empty;
            NextTime = string.Empty;
        }
    }
}