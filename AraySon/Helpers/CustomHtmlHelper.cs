// CustomHtmlHelper.cs
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AraySon.Helpers
{
    public class EditButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [HtmlAttributeName("asp-id")]
        public string Id { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"/{Controller}/{Action}/{Id}");
            output.Attributes.SetAttribute("class", "btn btn-warning edit-button");
            output.Attributes.SetAttribute("style", "background-color: #5D1414; color: white;");
            output.Content.SetContent("Düzenle");
        }
    }

    public class DeleteButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [HtmlAttributeName("asp-id")]
        public string Id { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"/{Controller}/{Action}/{Id}");
            output.Attributes.SetAttribute("class", "btn btn-danger delete-button");
            output.Attributes.SetAttribute("style", "background-color: #5D1414; color: white;");
            output.Content.SetContent("Sil");
        }
    }
}
