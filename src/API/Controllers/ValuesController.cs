using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("3.0-Alpha")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetV1()
        {
            return new[] { "value1", "value2" };
        }

        [HttpGet("GetV3"), MapToApiVersion("3")]
        public string GetV3() => "Hello world v2!";
    }
}