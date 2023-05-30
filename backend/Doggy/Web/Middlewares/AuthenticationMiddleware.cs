using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web.Middlewares
{
    public class AuthenticationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string tokenJson =
                context.Request.Headers["Authorization"].SingleOrDefault()?.Split(" ")?.Last()
                ?? string.Empty;

            bool isAuth = context.Request.Path.StartsWithSegments(new PathString("/api/auth"));

            if (this.IsValidToken(tokenJson) || isAuth)
            {
                await next(context);

                return;
            }

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }

        private bool IsValidToken(string token)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(token))
            {
                var jwtToken = new JwtSecurityTokenHandler().ReadToken(token);

                int res = DateTime.Compare(jwtToken.ValidTo, DateTime.Now);
                result = (res <= 0);
            }

            return result;
        }
    }
}
