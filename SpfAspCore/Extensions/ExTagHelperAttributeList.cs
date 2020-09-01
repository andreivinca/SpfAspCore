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
    public static class ExTagHelperAttributeList
    {
        public static void SetAttributeDictionary(this TagHelperAttributeList attrList, string id, RouteValueDictionary newAttrs)
        {
            attrList.SetAttribute("spf-attr", "");
            
            foreach (var d in newAttrs)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    attrList.SetAttribute(d.Key, d.Value);
                }
                attrList.SetAttribute("spf-attr-" + d.Key, d.Value);
            }
        }
    }
}
