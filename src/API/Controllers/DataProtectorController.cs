using System.Collections.Generic;
using CodeZero.Infrastructure.Controllers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
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
            string protectedPayload = _protector.Protect("value1");

            // unprotect the payload
            string unprotectedPayload = _protector.Unprotect(protectedPayload);

            _logger.LogInformation("payload {0} {1}", new[] { protectedPayload, unprotectedPayload });

            return new[] { protectedPayload, unprotectedPayload };
        }
    }
}