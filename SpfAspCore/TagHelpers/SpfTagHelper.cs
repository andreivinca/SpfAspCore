using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using SpfAspCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpfAspCore.TagHelpers
{
    [HtmlTargetElement("*", Attributes = "id")]
    [HtmlTargetElement("*", Attributes = "spf-placeholder-attr")]
    public class SpfTagHelper : TagHelper
    {
        public override void Init(TagHelperContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            base.Init(context);
        }

        /// <summary>
        /// The context of the current view
        /// </summary>
        [HtmlAttributeNotBound] // do not show in VS as something for users to add
        [ViewContext]
        public ViewContext ViewContext { get; set; } // set View Context property once constructed

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var id = context.GetAttrValueOrDefault("id");
            var spfPartialAttr = context.GetAttrValueOrDefault("spf-placeholder-attr");

            //if (id == null)
            //{
            //    return;
            //}

            var attrDictionary = ViewContext.GetSpfAttrDictionary();
            if(attrDictionary == null)
            {
                return;
            }

            object newAttrs;
            string attrValuesKey = id ?? spfPartialAttr;
            if (!attrDictionary.TryGetValue(attrValuesKey, out newAttrs))
            {
                return;
            }

            var newAttrDictionary = new RouteValueDictionary(newAttrs);
            output.Attributes.SetAttributeDictionary(id, newAttrDictionary);
        }
    }
}
