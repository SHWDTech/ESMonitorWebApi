using System.Linq;
using System.Web.Http;
using ESMonitorWebApi.Models.ESMonitor;
using ESMonitorWebApi.Models.Version;

namespace ESMonitorWebApi.Controllers
{
    public class VersionController : ApiController
    {
        private readonly EsMonitor _dbContext = new EsMonitor();

        public VersionViewModel Get([FromUri]string system)
        {
            var version = new VersionViewModel
            {
                version = _dbContext.SysConfig.First(obj => obj.ConfigType == "Version" && obj.ConfigName == system).ConfigValue.Trim(),
                versionCode = int.Parse(_dbContext.SysConfig.First(obj => obj.ConfigType == "VersionCode" && obj.ConfigName == system).ConfigValue.Trim()),
                description = _dbContext.SysConfig.First(obj => obj.ConfigType == "VersionDescription" && obj.ConfigName == system).ConfigValue.Trim(),
            };

            if (system == "Android")
            {
                version.VersionUrl =
                    _dbContext.SysConfig.First(obj => obj.ConfigType == "VersionUrl" && obj.ConfigName == system)
                        .ConfigValue.Trim();
            }
            return version;
        }
    }
}
