using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpfAspCore.SPFBuilder
{
    public static class SpfHTMLNode
    {
        public static void AddSPFContent(this HtmlNode node, JObject result)
        {
            var spfAttribute = node.Attributes["spf-content"];
            if (spfAttribute == null)
            {
                return;
            }

            result.AppendNodePath(spfAttribute.Value, node.OuterHtml);
        }

        public static void AddSPFTitle(this HtmlNode node, JObject result)
        {
            result.Add("title", node.InnerText);
        }
    }
}
