using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure
{
    //Build a tag helper
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        //Constructor
        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        
        // Adds to the dictionary when attributes with the common prefix are made
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        //Set up properties for bootstrap
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //Override method
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            //Create a div for the page links
            TagBuilder result = new TagBuilder("div");

            //Loop through as long as we are less than or equal to the number of pages
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                //Create a link to the page
                TagBuilder tag = new TagBuilder("a");

                //Set the page number
                PageUrlValues["page"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                //Add CSS classes
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);

                    //Change selected to be highlighted
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);

                }

                tag.InnerHtml.Append(i.ToString());

                //Add the page link to the list of links
                result.InnerHtml.AppendHtml(tag);
            }

            //Output the list of page links
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
