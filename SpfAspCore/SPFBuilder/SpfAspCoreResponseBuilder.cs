using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using SpfAspCore.SPFBuilder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SPFSpfAspCoreJSASPCORE.SPFBuilder
{
    public class SpfAspCoreResponseBuilder
    {
        MemoryStream _stream;
        
        public SpfAspCoreResponseBuilder(MemoryStream stream)
        {
            this._stream = stream;
        }

        private HtmlAgilityPack.HtmlDocument _htmlDocument;
        private HtmlAgilityPack.HtmlDocument HtmlDocument
        {
            get
            {
                if(_htmlDocument == null)
                {
                    this._htmlDocument  = new HtmlAgilityPack.HtmlDocument();
                    this._htmlDocument.Load(this._stream);
                }

                return this._htmlDocument;
            }
        }

        public byte[] Build()
        {
            var result = new JObject();

            //add title

            var titleNode = GetSPFTitleNode();
            if (titleNode != null)
            {
                titleNode.AddSPFTitle(result);
            }

            // add content
            foreach (var node in GetSPFContentNodes())
            {
                node.AddSPFContent(result);
            }

            var sResult = result.ToString();
            var bResult = Encoding.UTF8.GetBytes(sResult);

            return bResult;
        }

        private HtmlNodeCollection GetSPFContentNodes()
        {
            var nodes = HtmlDocument.DocumentNode.SelectNodes("//*[@spf-content]");

            var a = nodes[0];
            return nodes;
        }

        private HtmlNode GetSPFTitleNode()
        {
            var nodes = HtmlDocument.DocumentNode.SelectSingleNode("//title");

            return nodes;
        }



    }
}
