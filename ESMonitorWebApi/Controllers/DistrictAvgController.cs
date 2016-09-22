using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ESMonitorWebApi.Common;
using ESMonitorWebApi.Models.District;
using ESMonitorWebApi.Models.ESMonitor;

namespace ESMonitorWebApi.Controllers
{
    public class DistrictAvgController : ApiController
    {
        private readonly EsMonitor _dbContext = new EsMonitor();

        public IEnumerable<DistrictAvg> Post()
        {
            var type = Global.GetProjectType(int.Parse(HttpContext.Current.Request["projectType"]));
            var districtGroups = _dbContext.Stats.Where(item => item.ProType == type).GroupBy(obj => obj.Country);
            var dataType = int.Parse(HttpContext.Current.Request["dataType"]);

            var avgs = new List<DistrictAvg>();
            if (dataType == 0)
            {
                foreach (var districtGroup in districtGroups)
                {
                    var dis = new DistrictAvg();
                    var country = _dbContext.Country.First(obj => obj.Id == districtGroup.Key);
                    dis.name = country.Country.Trim();
                    dis.count = districtGroup.Count();
                    dis.district = districtGroup.Key;
                    var total = districtGroup
                        .Select(statse => _dbContext.EsMin
                            .Where(item => item.StatId == statse.Id)
                            .OrderByDescending(obj => obj.UpdateTime)
                            .FirstOrDefault())
                        .Where(obj => obj != null)
                        .Select(min => min.TP).Sum();
                    dis.tspAvg = Math.Round(total / dis.count / 1000.0, 2);

                    avgs.Add(dis);
                }
            }

            if (dataType == 1)
            {
                foreach (var districtGroup in districtGroups)
                {
                    var dis = new DistrictAvg();
                    var country = _dbContext.Country.First(obj => obj.Id == districtGroup.Key);
                    dis.name = country.Country.Trim();
                    dis.count = districtGroup.Count();
                    dis.district = districtGroup.Key;
                    var total = districtGroup
                        .Select(statse => _dbContext.EsDay
                            .Where(item => item.StatId == statse.Id)
                            .OrderByDescending(obj => obj.UpdateTime)
                            .FirstOrDefault())
                        .Where(obj => obj != null)
                        .Select(min => min.TP).Sum();
                    dis.tspAvg = Math.Round(total / dis.count / 1000.0, 2);

                    avgs.Add(dis);
                }
            }

            if (dataType == 2)
            {
                var month = DateTime.Parse($"{DateTime.Now.Year}-{DateTime.Now.Month}-01");
                foreach (var districtGroup in districtGroups)
                {
                    var dis = new DistrictAvg();
                    var country = _dbContext.Country.First(obj => obj.Id == districtGroup.Key);
                    dis.name = country.Country.Trim();
                    dis.count = districtGroup.Count();
                    dis.district = districtGroup.Key;
                    var total = districtGroup
                        .Select(statse => _dbContext.EsDay
                            .Where(item => item.StatId == statse.Id && item.UpdateTime > month))
                            .Where(obj => obj.Any())
                        .Sum(obj => obj.Average(item => item.TP));
                    dis.tspAvg = Math.Round(total / dis.count / 1000.0, 2);

                    avgs.Add(dis);
                }
            }

            return avgs;
        }
    }
}
