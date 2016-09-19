using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ESMonitorWebApi.Models.District;
using ESMonitorWebApi.Models.ESMonitor;

namespace ESMonitorWebApi.Controllers
{
    public class SpreadController : ApiController
    {
        private readonly EsMonitor _dbContext = new EsMonitor();

        public IEnumerable<Spread> Get()
        {
            var spreadList = new List<Spread>();

            var proOne = _dbContext.Stats.Where(obj => obj.ProType == "商业地产");
            var mins = proOne.Select(stat => _dbContext.EsMin
                        .Where(item => item.StatId == stat.Id)
                        .OrderByDescending(obj => obj.UpdateTime)
                        .FirstOrDefault());

            var spread = new Spread
            {
                projectType = 1,
                good = mins.Count(obj => obj.TP < 400),
                normal = mins.Count(obj => obj.TP > 400 && obj.TP < 1000),
                bad = mins.Count(obj => obj.TP > 1000)
            };

            spreadList.Add(spread);

            return spreadList;
        }
    }
}
