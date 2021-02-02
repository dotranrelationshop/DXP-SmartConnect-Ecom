using DXP.SmartConnect.Ecom.Core.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DXP.SmartConnect.Ecom.API.Controllers
{
    public class AppController : BaseApiController
    {
        private readonly ReadmeSettings _configuration;

        public AppController(IOptions<ReadmeSettings> config)
        {
            _configuration = config.Value;
        }

        /// <summary>
        /// Returns Readme information.
        /// </summary>
        /// <returns>Dynamic.</returns>
        [HttpGet("/readme")]
        public dynamic Info()
        {
            return new
            {
                Server = $"{System.Net.Dns.GetHostName()}",
                BuildNumber = _configuration.BuildNumber,
                BuildVersion = _configuration.Version,
                ReleaseDate = _configuration.ReleaseDate,
                Commit = _configuration.Commit
            };
        }
    }
}
