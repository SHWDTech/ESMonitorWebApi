using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using ESMonitorWebApi.Common;
using ESMonitorWebApi.Models.ESMonitor;
using ESMonitorWebApi.Models.Map;
using System;

namespace ESMonitorWebApi.Controllers
{
    public class MapController : ApiController
    {
        private readonly EsMonitor _dbContext = new EsMonitor();

        /// <summary>
        /// 获取工地地图信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MapStat> Post()
        {
            var type = Global.GetProjectType(int.Parse(HttpContext.Current.Request["projectType"]));
            var mapstats = new List<MapStat>();
            var stats = _dbContext.Stats.Where(obj => obj.ProType == type);
            if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request["district"]))
            {
                var district = int.Parse(HttpContext.Current.Request["district"]);
                stats = stats.Where(obj => obj.Country == district);
            }

            if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request["stat"]))
            {
                var stat = int.Parse(HttpContext.Current.Request["stat"]);
                stats = stats.Where(obj => obj.Country == stat);
            }

            foreach (var stat in stats)
            {
                var min = _dbContext.EsMin.OrderByDescending(obj => obj.UpdateTime)
                        .FirstOrDefault(item => item.StatId == stat.Id);
                var mapStat = new MapStat
                {
                    id = stat.Id,
                    name = stat.StatName.Trim(),
                    latitude = stat.Latitude.ToString(CultureInfo.InvariantCulture),
                    longitude = stat.Longitude.ToString(CultureInfo.InvariantCulture)
                };
                if (min != null)
                {
                    if (min.UpdateTime != null) mapStat.time = min.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    mapStat.tsp = Math.Round(min.TP / 1000.0 , 2);
                    mapStat.rate = Global.GetRate(min.TP / 1000.0);
                }
                mapstats.Add(mapStat);
            }
            return mapstats;
        }
    }
}
