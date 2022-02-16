using Markdig;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CustomTagHelpers;

[HtmlTargetElement("markdown", TagStructure = TagStructure.NormalOrSelfClosing)]
[HtmlTargetElement(Attributes = "markdownfile")]
public class MarkdownTagHelper : TagHelper
{
   private readonly IWebHostEnvironment _env;
   public MarkdownTagHelper(IWebHostEnvironment env) => _env = env;

   [HtmlAttributeName("markdownfile")]
   public string? MarkdownFile { get; set; }

   public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
   {
      string markdown;
      if (MarkdownFile is not null)
      {
         var filename = Path.Combine(_env.WebRootPath, MarkdownFile);
         markdown = await File.ReadAllTextAsync(filename).ConfigureAwait(false);
      }
      else
      {
         markdown = (await output.GetChildContentAsync().ConfigureAwait(false)).GetContent();
      }

      var html = Markdown.ToHtml(markdown);
      output.Content.SetHtmlContent(html);
   }
}