////using CodeZero.Feature;
using CodeZero.Configuration.Models;
using CodeZero.Infrastructure.Controllers;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
////using Microsoft.FeatureManagement;
////using Microsoft.FeatureManagement.Mvc;

namespace CodeZeroTemplate.API.Controllers
{
    //[FeatureGate(FeatureFlags.Authentication)]
    //[FeatureGate(RequirementType.All, FeatureFlags.CoreFeature.Authentication, FeatureFlags.CoreFeature.EnableMemoryCache)]
    public class AntiForgeryController : AnonymousController
    {
        private readonly IAntiforgery _antiForgery;

        public AntiForgeryController(IAntiforgery antiForgery)
        {
            _antiForgery = antiForgery;
        }

        //// GET api/contacts/{guid}
        ////[HttpGet("{id}", Name = "GetById")]
        [HttpGet("Get")]
        [IgnoreAntiforgeryToken]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status204NoContent)]
        public IActionResult GenerateAntiForgeryTokens()
        {
            var tokens = _antiForgery.GetAndStoreTokens(HttpContext).RequestToken;
            Response.Cookies.Append("XSRF-REQUEST-TOKEN", $"{tokens}", new Microsoft.AspNetCore.Http.CookieOptions
            {
                Secure = true,
                HttpOnly = true
            });

            return NoContent();
        }

        [HttpGet("TestValidateToken")]
        [ValidateAntiForgeryToken]
        public string TestValidateAntiForgeryToken()
        {
            var tokens = _antiForgery.GetAndStoreTokens(HttpContext).RequestToken;
            Response.Cookies.Append("XSRF-REQUEST-TOKEN", $"{tokens}", new Microsoft.AspNetCore.Http.CookieOptions
            {
                Secure = true,
                HttpOnly = true
            });

#pragma warning disable CS8603 // Possible null reference return.
            return tokens;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}