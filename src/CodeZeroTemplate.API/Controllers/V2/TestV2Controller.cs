using Microsoft.AspNetCore.Mvc;

namespace CodeZeroTemplate.API.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class TestV2Controller : ControllerBase
    {
        ////readonly ICoreConfiguration CoreConfiguration;

        ////public TestV2Controller(ICoreConfiguration CoreConfiguration)
        ////{
        ////    this.CoreConfiguration = CoreConfiguration;
        ////}

        ////[HttpGet]
        ////public ICoreConfiguration GetV2()
        ////{
        ////    return CoreConfiguration;
        ////}

        [HttpGet]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S3400:Methods should not return constants", Justification = "<Pending>")]
        public string GetV2()
        {
            return "v2";
        }
    }
}