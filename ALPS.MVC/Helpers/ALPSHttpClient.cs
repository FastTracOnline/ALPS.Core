using ALPS.Common;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;

namespace ALPS.MVC.Helpers
{
    public static class ALPSHttpClient
    {
        public static HttpClient GetApiClient(string baseAddress = null, string requestedVersion = null)
        {
            //CheckAndPossiblyRefreshToken((HttpContext.Current.User.Identity as ClaimsIdentity));

            HttpClient client = new HttpClient();

            //var token = (HttpContext.Current.User.Identity as ClaimsIdentity).FindFirst("access_token");
            //if (token != null)
            //{
            //    client.SetBearerToken(token.Value);
            //}

            if (!string.IsNullOrWhiteSpace(baseAddress))
                client.BaseAddress = new Uri(baseAddress);
            else
                client.BaseAddress = new Uri(ALPSConstants.ALPSAPI);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            if (requestedVersion != null)
            {
                // through a custom request header
                client.DefaultRequestHeaders.Add("api-version", requestedVersion);

                // through content negotiation
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.api.v"
                        + requestedVersion + "+json"));
            }

            return client;
        }

        //public static HttpClient GetIdentityClient()
        //{
        //    HttpClient client = new HttpClient();

        //    client.BaseAddress = new Uri(ALPSConstants.IdSrv);

        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    return client;
        //}

        //private static async void CheckAndPossiblyRefreshToken(ClaimsIdentity id)
        //{
        //    // check if the access token hasn't expired.
        //    if (DateTime.Now.ToLocalTime() >=
        //         (DateTime.Parse(id.FindFirst("expires_at").Value)))
        //    {
        //        var tokenClient = new TokenClient(ALPSConstants.IdSrvToken, "mvc", "secret");
        //        var tokenResponse = await tokenClient.RequestRefreshTokenAsync(id.FindFirst("refresh_token").Value);

        //        if (!tokenResponse.IsError)
        //        {
        //            // replace the claims with the new values - this means creating a 
        //            // new identity!                              
        //            var result = from claim in id.Claims
        //                         where claim.Type != "access_token" && claim.Type != "refresh_token" &&
        //                               claim.Type != "expires_at"
        //                         select claim;

        //            var claims = result.ToList();

        //            claims.Add(new Claim("access_token", tokenResponse.AccessToken));
        //            claims.Add(new Claim("expires_at", DateTime.Now.AddSeconds(tokenResponse.ExpiresIn).ToLocalTime().ToString()));
        //            claims.Add(new Claim("refresh_token", tokenResponse.RefreshToken));

        //            var newIdentity = new ClaimsIdentity(claims, "Cookies");
        //        }
        //        else
        //        {
        //            // log, ...
        //            throw new Exception("An error has occurred");
        //        }
        //    }
        //}
    }
}