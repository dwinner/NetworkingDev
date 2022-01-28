using System;
using System.IO;
using Markdig;

namespace MarkdownSample
{
   internal static class Program
   {
      private static void Main()
      {
         try
         {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var filename = Path.Combine(Directory.GetCurrentDirectory(), "MarkdownSample1.md");
            var markdown = File.ReadAllText(filename);
            var html = Markdown.ToHtml(markdown, pipeline);
            Console.WriteLine(html);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex);
         }
      }
   }
}