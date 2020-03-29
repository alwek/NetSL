using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetSL.Api.Services;

namespace NetSL.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}")]
    [ApiController]
    public class TrafficController : ControllerBase
    {
        private readonly ITrafficService _serivce;
        private readonly ILogger<TrafficController> _logger;

        public TrafficController(ITrafficService service, ILogger<TrafficController> logger)
        {
            _serivce = service;
            _logger = logger;
        }

        [HttpGet("trafficsituation")]
        public async Task<IActionResult> GetTrafficSituation()
        {
            _logger.LogInformation($"Traffic Situation called from host: {Request.Host.Host}");
            return Ok(await _serivce.GetTrafficSituation());
        }

        [HttpGet("realtimeinformation")]
        public async Task<IActionResult> GetRealtimeInformation(int siteId, int timeWindow)
        {
            if(siteId <= 0 || timeWindow <= 0)
                return BadRequest("Missing or invalid parameters. Expected <SiteId> and <TimeWindow>");

            _logger.LogInformation($"Realtime Information called from host: {Request.Host.Host}");
            return Ok(await _serivce.GetRealtimeInformation(siteId, timeWindow));
        }

        [HttpGet("deviationinformation")]
        public async Task<IActionResult> GetDeviationInformation(string transportMode, string lineNumber, int siteId, string fromDate, string toDate)
        {
            if(string.IsNullOrEmpty(transportMode) || 
                string.IsNullOrEmpty(lineNumber) || 
                string.IsNullOrEmpty(fromDate) || 
                string.IsNullOrEmpty(toDate) || 
                siteId <= 0)
                return BadRequest("Missing or invalid parameters." + 
                    "Expected <TransportMode>, <LineNumber>, <SiteId>, <FromDate> and <ToDate>");

            _logger.LogInformation($"Deviation Information called from host: {Request.Host.Host}");
            return Ok(await _serivce.GetDeviationInformation(transportMode, lineNumber, siteId, fromDate, toDate));
        }

        [HttpGet("stations")]
        public async Task<IActionResult> GetStations(string searchString)
        {
            if(string.IsNullOrEmpty(searchString))
                return BadRequest("Missing or invalid parameters. Expected <SearchString>.");

            _logger.LogInformation($"Stations search called from host: {Request.Host.Host}");
            return Ok(await _serivce.GetStations(searchString));
        }
    }
}
