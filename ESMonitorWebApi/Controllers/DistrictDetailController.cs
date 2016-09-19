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
    public class DistrictDetailController : ApiController
    {
        private readonly EsMonitor _dbContext = new EsMonitor();

        public IEnumerable<DistrictDetail> Post()
        {
            var type = Global.GetProjectType(int.Parse(HttpContext.Current.Request["projectType"]));
            var district = int.Parse(HttpContext.Current.Request["district"]);
            var country = _dbContext.Country.First(obj => obj.Id == district);
            var stats = _dbContext.Stats.Where(obj => obj.ProType == type);
            var details = new List<DistrictDetail>();
            foreach (var stat in stats)
            {
                var min = _dbContext.EsMin.Where(obj => obj.StatId == stat.Id)
                        .OrderByDescending(item => item.UpdateTime)
                        .First();
                var detail = new DistrictDetail
                {
                    districtName = country.Country.Trim(),
                    id = stat.Id,
                    name = stat.StatName.Trim(),
                    tsp = Math.Round(min.TP / 1000.0, 2),
                    rate = Global.GetRate(min.TP / 1000.0)
                };

                details.Add(detail);
            }
            return details;
        }
    }
}
