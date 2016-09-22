using System.Linq;
using System.Web.Http;
using ESMonitorWebApi.Models.District;
using ESMonitorWebApi.Models.ESMonitor;

namespace ESMonitorWebApi.Controllers
{
    public class SpreadController : ApiController
    {
        private readonly EsMonitor _dbContext = new EsMonitor();

        public Spread Get()
        {
            var spread = new Spread();

            var proOne = _dbContext.Stats.Where(obj => obj.ProType == "商业地产");
            var mins = proOne.Select(stat => _dbContext.EsMin
                        .Where(item => item.StatId == stat.Id)
                        .OrderByDescending(obj => obj.UpdateTime)
                        .FirstOrDefault())
                        .Where(obj => obj != null);

            spread.city = _dbContext.Province.First().Province.Trim();
            var road = new Pie
            {
                projectType = 0,
                good = 0,
                normal = 0,
                bad = 0
            };
            spread.pieCharts.Add(road);

            var construction = new Pie
            {
                projectType = 1,
                good = mins.Count(obj => obj.TP < 400),
                normal = mins.Count(obj => obj.TP > 400 && obj.TP < 1000),
                bad = mins.Count(obj => obj.TP > 1000)
            };
            spread.pieCharts.Add(construction);

            var wharf = new Pie
            {
                projectType = 2,
                good = 0,
                normal = 0,
                bad = 0
            };
            spread.pieCharts.Add(wharf);

            var mixingplant = new Pie
            {
                projectType = 3,
                good = 0,
                normal = 0,
                bad = 0
            };
            spread.pieCharts.Add(mixingplant);

            return spread;
        }
    }
}
