using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;

namespace ALPS.Common
{
    public class ALPSConstants
    {
        public const string ALPSAPI = @"http://www.zerodefectsw.com/API/";
        //public const string ALPSClient = @"https://localhost:44302/";
        public const string ALPSMVC = @"http://www.zerodefectsw.com/ALPS/";
        //public const string ALPSMobile = @"ms-app://s-1-15-2-467734538-4209884262-1311024127-1211083007-3894294004-443087774-3929518054/";

        //public const string IdSrvIssuerUri = @"http://ALPSidsrv3/embedded";

        public const string IdSrv = @"http://www.zerodefectsw.com/Identity/";
        public const string IdSrvCore = IdSrv + @"core";
        public const string IdSrvToken = IdSrv + @"connect/token";
        public const string IdSrvAuthorize = IdSrvCore + @"connect/authorize";
        public const string IdSrvUserInfo = IdSrvCore + @"connect/userinfo";
    }
}

