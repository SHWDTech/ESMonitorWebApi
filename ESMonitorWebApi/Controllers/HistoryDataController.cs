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
    public class HistoryDataController : ApiController
    {
        private EsMonitor _dbContext;

        public IEnumerable<HistoryData> Post()
        {
            _dbContext = new EsMonitor(Global.GetConnString(HttpContext.Current.Request["city"]));
            var type = Global.GetProjectType(int.Parse(HttpContext.Current.Request["projectType"]));
            var dataType = int.Parse(HttpContext.Current.Request["type"]);
            var typeStats = _dbContext.Stats.Where(obj => obj.ProType == type);
            var statId = HttpContext.Current.Request["stat"].Split(',').Select(int.Parse);
            var stats = typeStats.Where(obj => statId.Contains(obj.Id)).ToArray();

            switch (dataType)
            {
                case 0:
                    return GetMinuteData(stats);
                case 1:
                    return GetHourData(stats);
                case 2:
                    return GetDayData(stats);
            }

            return null;
        }

        private IEnumerable<HistoryData> GetMinuteData(T_Stats[] stats)
        {
            var list = new List<HistoryData>();
            foreach (var stat in stats)
            {
                var his = new HistoryData
                {
                    stat = stat.Id
                };
                var mins = _dbContext.EsMin
                        .Where(obj => obj.StatId == stat.Id)
                        .OrderByDescending(item => item.UpdateTime)
                        .Take(30)
                        .OrderBy(data => data.UpdateTime);
                foreach (var esMin in mins)
                {
                    if (esMin.UpdateTime != null)
                        his.data.Add(new MonitorData
                        {
                            date = esMin.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                            rate = Global.GetRate(esMin.TP / 1000.0),
                            tsp = Math.Round(esMin.TP / 1000.0, 2),
                        });
                }

                list.Add(his);
            }
            return list;
        }

        private IEnumerable<HistoryData> GetHourData(T_Stats[] stats)
        {
            var list = new List<HistoryData>();
            foreach (var stat in stats)
            {
                var his = new HistoryData
                {
                    stat = stat.Id
                };
                var mins = _dbContext.EsHour
                        .Where(obj => obj.StatId == stat.Id)
                        .OrderByDescending(item => item.UpdateTime)
                        .Take(30);
                foreach (var esMin in mins)
                {
                        his.data.Add(new MonitorData
                        {
                            date = esMin.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                            rate = Global.GetRate(esMin.TP / 1000.0),
                            tsp = Math.Round(esMin.TP / 1000.0, 2),
                        });
                }

                list.Add(his);
            }

            return list;
        }

        private IEnumerable<HistoryData> GetDayData(T_Stats[] stats)
        {
            var list = new List<HistoryData>();
            foreach (var stat in stats)
            {
                var his = new HistoryData
                {
                    stat = stat.Id
                };
                var mins = _dbContext.EsDay
                        .Where(obj => obj.StatId == stat.Id)
                        .OrderByDescending(item => item.UpdateTime)
                        .Take(30);
                foreach (var esMin in mins)
                {
                    his.data.Add(new MonitorData
                    {
                        date = esMin.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        rate = Global.GetRate(esMin.TP / 1000.0),
                        tsp = Math.Round(esMin.TP / 1000.0, 2),
                    });
                }

                list.Add(his);
            }

            return list;
        }
    }
}
