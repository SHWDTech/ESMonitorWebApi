using System.Web.Http;

namespace ESMonitorWebApi.Controllers
{
    public class CityController : ApiController
    {
        public string[] Get()
        {
            return new[] {"上海", "昆山"};
        }
    }
}