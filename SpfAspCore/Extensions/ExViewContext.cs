using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpfAspCore.Extensions
{
    public static class ExViewContext
    {
        public static RouteValueDictionary GetSpfAttrDictionary(this ViewContext context)
        {
            var value = context.ViewData["spf-attr"];
            if(value == null)
            {
                return null;
            }

            var dictionary = new RouteValueDictionary(value);
            return dictionary;
        }
    }
}
