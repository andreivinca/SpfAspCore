using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using SpfAspCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpfAspCore.Extensions
{
    public static class ExSpfHTMLNode
    {
        public static void AddSpfContent(this HtmlNode node, JObject result)
        {
            var spfAttribute = node.Attributes["spf-content"];
            if (spfAttribute == null)
            {
                return;
            }

            result.AppendNodePath(spfAttribute.Value, node.OuterHtml);
        }

        public static void AddSpfAttr(this HtmlNode node, JObject result)
        {
            var spfAttribute = node.Attributes.Where(i => i.Name.ToLower().StartsWith("spf-attr-"));
            if (!spfAttribute.Any())
            {
                return;
            }

            var id = node.GetSpfPartialAttr() ?? node.Id;

            foreach (var attr in spfAttribute)
            {
                var name = attr.Name.TrimStart("spf-attr-");

                var path = $"attr/{id}/{name}";
                result.AppendNodePath(path, attr.Value);
            }
        }

        public static void AddSpfTitle(this HtmlNode node, JObject result)
        {
            result.Add("title", node.InnerText);
        }

        public static string GetSpfPartialAttr(this HtmlNode node)
        {
            var partialAttr = node.Attributes["spf-placeholder-attr"];
            if(partialAttr == null)
            {
                return null;
            }

            return partialAttr.Value;
        }
    }
}
