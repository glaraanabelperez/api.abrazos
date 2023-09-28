using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;


namespace Models
{

    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public ApplicationDbContext _db;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
            ) : base(options, logger, encoder, clock)
        {
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
                var username = credentials[0];
                var password = credentials[1];

                using (IDbContextTransaction trans = _db.Database.BeginTransaction())
                {
                    try{

                    }catch(Exception e)
                    {
                        throw new Exception("Error in the authtentication");
                    }
                    var user = _db.Users
                       .Where(u => u.UserName == username && u.Pass== password)
                       .SingleOrDefault();
                }

                if (username == "test" && password == "123")
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, username) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Invalid Username or Password");
                }
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Error: {ex.Message}");
            }
        }
    }
}
   
