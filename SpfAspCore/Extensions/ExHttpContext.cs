using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpfAspCore.Extensions
{
    public static class ExHttpContext
    {
        public static bool IsSPFRequest(this HttpContext context)
        {
            if (context == null)
            {
                return false;
            }
            StringValues spfValue;
            if (context.Request.Query.TryGetValue("spf", out spfValue))
            {
                return true;
            }

            return false;
        }
    }
}
