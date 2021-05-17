using CodeZero.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class TestV2Controller : ControllerBase
    {
        //readonly ICoreConfiguration CoreConfiguration;

        //public TestV2Controller(ICoreConfiguration CoreConfiguration)
        //{
        //    this.CoreConfiguration = CoreConfiguration;
        //}

        //[HttpGet]
        //public ICoreConfiguration GetV2()
        //{
        //    return CoreConfiguration;
        //}

        [HttpGet]
        public string GetV2()
        {
            return "v2";
        }
    }
}