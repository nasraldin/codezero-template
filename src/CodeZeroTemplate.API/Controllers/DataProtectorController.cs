using System.Collections.Generic;
using CodeZero.Infrastructure.Controllers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeZeroTemplate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataProtectorController : BaseController
    {
        private readonly IDataProtector _protector;
        private readonly ILogger<DataProtectorController> _logger;

        public DataProtectorController(IDataProtectionProvider provider, ILogger<DataProtectorController> logger)
        {
            _protector = provider.CreateProtector("CodeZero.DataProtectorController");
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            // protect the payload
            var protectedPayload = _protector.Protect("value1");

            // unprotect the payload
            var unprotectedPayload = _protector.Unprotect(protectedPayload);

            _logger.LogInformation("payload {0} {1}", new[] { protectedPayload, unprotectedPayload });


            ////var timeLimitedProtector = _protector.ToTimeLimitedDataProtector();
            ////var timeLimitedData = timeLimitedProtector.Protect("Test timed protector", lifetime: TimeSpan.FromSeconds(2));
            //////just to test that this action works as long as life-time hasn't expired
            ////var timedUnprotectedData = timeLimitedProtector.Unprotect(timeLimitedData);
            ////Thread.Sleep(3000);
            ////var anotherTimedUnprotectTry = timeLimitedProtector.Unprotect(timeLimitedData);

            return new[] { protectedPayload, unprotectedPayload };
        }
    }
}