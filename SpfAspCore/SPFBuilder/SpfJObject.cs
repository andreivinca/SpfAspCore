using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpfAspCore.SPFBuilder
{
    public static class SpfJObject
    {
        public static void AppendNodePath(this JObject result, string path, string htmlValue)
        {
            var nodesPath = path.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);

            JToken lastProperty = result;

            foreach (var sNode in nodesPath)
            {
                var existingValue = lastProperty[sNode];
                if (existingValue != null)
                {
                    lastProperty = (JToken)existingValue;
                    continue;
                }

                var newProperty = new JObject();

                if ((lastProperty is JObject) == false)
                {
                    throw new System.Exception("Content cannot be declared as child to another content");
                }

                ((JObject)lastProperty).Add(sNode, newProperty);
                lastProperty = newProperty;
            }

            if (((Newtonsoft.Json.Linq.JProperty)((JContainer)lastProperty.Parent)).Value is Newtonsoft.Json.Linq.JValue)
            {
                var existingValue = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JProperty)((JContainer)lastProperty.Parent)).Value).Value.ToString();
                ((Newtonsoft.Json.Linq.JProperty)((JContainer)lastProperty.Parent)).Value = new JValue(existingValue + htmlValue);
                return;
            }

             ((Newtonsoft.Json.Linq.JProperty)((JContainer)lastProperty.Parent)).Value = new JValue(htmlValue);
        }
    }
}
