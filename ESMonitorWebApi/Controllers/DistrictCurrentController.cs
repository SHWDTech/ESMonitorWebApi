using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ESMonitorWebApi.Common;
using ESMonitorWebApi.Models.District;
using ESMonitorWebApi.Models.ESMonitor;
using System;

namespace ESMonitorWebApi.Controllers
{
    public class DistrictCurrentController : ApiController
    {
        private EsMonitor _dbContext;

        public IEnumerable<DistrictAvg> Post()
        {
            _dbContext = new EsMonitor(Global.GetConnString(HttpContext.Current.Request["city"]));
            var type = Global.GetProjectType(int.Parse(HttpContext.Current.Request["projectType"]));
            var districtGroups = _dbContext.Stats.Where(item => item.ProType == type).GroupBy(obj => obj.Country);

            var avgs = new List<DistrictAvg>();
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

            return avgs;
        }
    }
}