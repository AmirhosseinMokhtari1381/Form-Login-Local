using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Contactus1.TagHelpers
{
    [HtmlTargetElement(Attributes = "bold")]
    public class Bold:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.AppendHtml("<strong>");
            output.PostContent.AppendHtml("</strong>");
            output.Attributes.Add("stylde", "font-size:48px");
            base.Process(context, output);  
        }
    }
}
