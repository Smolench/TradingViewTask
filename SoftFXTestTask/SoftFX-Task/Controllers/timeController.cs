using System;

namespace SoftFXTestTask.Controllers
{
    public class TimeController : ApiBase
    {
        public long Get()
        {
            var unixTime = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds / 1000;
            return unixTime;
        }
    }
}
