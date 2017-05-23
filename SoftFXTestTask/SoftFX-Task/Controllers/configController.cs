using Newtonsoft.Json;
using SoftFXTestTask.Chart;

namespace SoftFXTestTask.Controllers
{
    public class ConfigController : ApiBase
    {
        public string Get()
        {
            return JsonConvert.SerializeObject(new Configuration());
        }
    }
}