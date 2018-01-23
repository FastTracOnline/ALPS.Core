using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ALPS.API.Helpers
{
    public static class RequestHandler
    {
        public static int RepossessorId(HttpRequestMessage request)
        {
            // TODO: Retrieve Reposessor Id from User Token (Claim)
            int RepossessorId = 0;
            try
            {
                IEnumerable<string> y = null;
                if (request.Headers.TryGetValues("api-client", out y))
                    RepossessorId = int.Parse(y.First());
            }
            catch
            {
                RepossessorId = 0;
            }

            return RepossessorId;
        }
    }
}