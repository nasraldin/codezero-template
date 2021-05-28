////using CodeZero.Configuration;
////using CodeZero.Feature;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodeZeroTemplate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("3.0-Alpha")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetV1()
        {
            ////var test = AppSettings.Instance.FeatureManager.IsEnabledAsync(nameof(FeatureFlags.CoreFeature.Authentication)).ConfigureAwait(false).GetAwaiter().GetResult();
            return new[] { "value1", "value2", $"ww" };
        }

        [HttpGet("GetV3"), MapToApiVersion("3")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S3400:Methods should not return constants", Justification = "<Pending>")]
        public string GetV3() => "Hello world v2!";
    }
}