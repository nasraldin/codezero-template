using System.Collections.Generic;
using CodeZero;
using CodeZero.Infrastructure.Controllers;
using Microsoft.AspNetCore.Mvc;
////using Microsoft.Extensions.Localization;

namespace CodeZeroTemplate.API.Controllers
{
    [ApiController]
    //[ApiVersion("1.0")] // you can use ApiVersion
    [Route("api/v{api-version:apiVersion}/[controller]")] // or use your custome ver like v1,v2.0 in route
    public class TestValV1Controller : AnonymousController
    {
        ////private readonly IStringLocalizer _l;

        public TestValV1Controller()
        {
            ////_l = l;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = false)]
        public IEnumerable<string> GetV1()
        {

            // TODO: fix http request https://stackoverflow.com/questions/59963383/session-setstring-method-throws-exception-ifeaturecollection-has-been-disposed
            var test = CodeZeroHelper.HttpContext.Request.Headers["Accept-Language"].ToString();
            ////var lng = _l["appTitle"];
            return new string[] { "value1", "value2", test };
        }
    }
}