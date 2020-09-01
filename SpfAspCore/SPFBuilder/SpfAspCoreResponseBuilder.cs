using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using SpfAspCore.Extensions;
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
                titleNode.AddSpfTitle(result);
            }

            //add attrs
            var attrNodes = GetSPFAttrNodes();
            if(attrNodes != null)
            {
                foreach (var node in attrNodes)
                {
                    node.AddSpfAttr(result);
                }
            }

            // add content
            var contentNodes = GetSPFContentNodes();

            if (contentNodes != null)
            {
                foreach (var node in contentNodes)
                {
                    node.AddSpfContent(result);
                }
            }
            
            var sResult = result.ToString();
            var bResult = Encoding.UTF8.GetBytes(sResult);

            return bResult;
        }

        private HtmlNodeCollection GetSPFContentNodes()
        {
            var nodes = HtmlDocument.DocumentNode.SelectNodes("//*[@spf-content]");
            return nodes;
        }

        private HtmlNode GetSPFTitleNode()
        {
            var nodes = HtmlDocument.DocumentNode.SelectSingleNode("//title");

            return nodes;
        }

        private HtmlNodeCollection GetSPFAttrNodes()
        {
            var nodes = HtmlDocument.DocumentNode.SelectNodes("//*[@spf-attr]");
            return nodes;
        }



    }
}
