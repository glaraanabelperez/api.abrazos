
using Abrazos.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Utils;

namespace ServicesQueries.Auth
{

    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public IUserQueryService _userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserQueryService userService
            ) : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var email = credentials[0];
                var password = credentials[1];

                if (RegexUtilities.IsValidEmail(email))
                {
                    var user = await _userService.LoginAsync(email, password);
                    if (user.Succeeded.HasValue)
                    {
                        var claims = new[] { new Claim(ClaimTypes.Name, email) };
                        var identity = new ClaimsIdentity(claims, Scheme.Name);
                        var principal = new ClaimsPrincipal(identity);
                        var ticket = new AuthenticationTicket(principal, Scheme.Name);

                        return AuthenticateResult.Success(ticket);
                    }
                    else
                    {
                        return AuthenticateResult.Fail("Invalid Email or Password");
                    }
                }
                else
                {
                    return AuthenticateResult.Fail("Invalid Email's format");
                }


            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Error: {ex.Message}");
            }
        }
    }
}

