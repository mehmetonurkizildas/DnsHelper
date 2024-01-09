using DnsHelper.Services;
using Microsoft.AspNetCore.Mvc;

namespace DnsHelper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DnsHelperController : ControllerBase
    {
        //https://dnsclient.michaco.net/

        private readonly ILogger<DnsHelperController> _logger;
        private readonly IDnsHelperService _dnsHelperService;

        public DnsHelperController(ILogger<DnsHelperController> logger, IDnsHelperService dnsHelperService)
        {
            _logger = logger;
            _dnsHelperService = dnsHelperService;
        }

        [HttpGet("GetARecords")]
        public IActionResult GetARecords(string domain)
        {
            return Ok(_dnsHelperService.GetARecords(domain));
        }

        [HttpGet("GetMxRecords")]
        public IActionResult GetMxRecords(string domain)
        {
            return Ok(_dnsHelperService.GetMxRecords(domain));
        }

        [HttpGet("GetNsRecords")]
        public IActionResult GetNsRecords(string domain)
        {
            return Ok(_dnsHelperService.GetNsRecords(domain));
        }
    }
}
