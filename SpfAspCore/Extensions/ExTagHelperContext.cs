using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpfAspCore.Extensions
{
    public static class ExTagHelperContext
    {
        public static string GetAttrValueOrDefault(this TagHelperContext context, string name, string defaultValue = null)
        {
            var attr = context.AllAttributes[name];
            if (attr == null)
            {
                return defaultValue;
            }
            var value = ((Microsoft.AspNetCore.Html.HtmlString)attr.Value).Value;
            return value;
        }
    }
}
