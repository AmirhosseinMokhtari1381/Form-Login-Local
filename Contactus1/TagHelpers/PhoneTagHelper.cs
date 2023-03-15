 using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Contactus1.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("call",TagStructure =TagStructure.NormalOrSelfClosing)]
    public class PhoneTagHelper : TagHelper
    {
        public string PhoneNumber { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href",$"tell {PhoneNumber}" );
            output.Content.AppendHtml($"Call{ PhoneNumber}");
            base.Process(context,output);

        }
    }
}
