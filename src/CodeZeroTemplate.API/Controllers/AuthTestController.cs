using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeZero.Infrastructure.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CodeZeroTemplate.API.Controllers
{
    public class AuthTestController : AnonymousController
    {
        private readonly IConfiguration _configuration;

        public AuthTestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return new string[]
            {
                $"{_configuration["Authentication:Authority"]}/.well-known/openid-configuration",
                $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/values",
                $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/signin-oidc",
                $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/signout-oidc",
                "==== IDENTITY ===============",
#pragma warning disable CS8601 // Possible null reference assignment.
                HttpContext.User?.Identity?.Name,
#pragma warning restore CS8601 // Possible null reference assignment.
                //"==== CLAIMS ===============",
#pragma warning disable CS8601 // Possible null reference assignment.
                HttpContext.User?.Claims?.Any() == true ? HttpContext.User?.Claims?.Select(h => $"CLAIM {h.Type}: {h.Value}").Aggregate((i, j) => i + " | " + j) : null,
#pragma warning restore CS8601 // Possible null reference assignment.
                "==== TOKENS ===============",
#pragma warning disable CS8601 // Possible null reference assignment.
                HttpContext.User?.Identity?.IsAuthenticated == true ? "access_token: " + await HttpContext.GetTokenAsync("access_token") : null, // https://www.jerriepelser.com/blog/accessing-tokens-aspnet-core-2/
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                HttpContext.User?.Identity?.IsAuthenticated == true ? "id_token: " + await HttpContext.GetTokenAsync("id_token") : null,
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                HttpContext.User?.Identity?.IsAuthenticated == true ? "refresh_token: " + await HttpContext.GetTokenAsync("refresh_token") : null,
#pragma warning restore CS8601 // Possible null reference assignment.
                "==== HEADERS ===============",
                HttpContext.Request.Headers.Select(h => $"HEADER {h.Key}: {h.Value}").Aggregate((i, j) => i + " | " + j)
                //HttpContext.Items["username"] as string
            };
        }

        [Route("signin-oidc")]
        [HttpGet]
        public IActionResult Signin()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (HttpContext.User.Identity.IsAuthenticated)
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            {
                return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
            }

            return new ObjectResult(HttpContext.User.Identity);
        }

        [Route("signout-oidc")]
        [HttpGet]
        public IActionResult Signout()
        {
            var result = new SignOutResult(new[]
            {
                OpenIdConnectDefaults.AuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme,
            })
            {
                Properties = new AuthenticationProperties
                {
                    RedirectUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/"
                }
            };
            return result;
        }
    }
}