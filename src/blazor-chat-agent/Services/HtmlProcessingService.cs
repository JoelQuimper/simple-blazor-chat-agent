using System.Text.RegularExpressions;
using Ganss.Xss;

namespace BlazorChatAgent.Services;

public class HtmlProcessingService
{
    public string ConvertMarkdownLinksToHtml(string text)
    {
        // Convert markdown links [text](url) to HTML <a> tags, removing trailing period from URL
        text = Regex.Replace(text, @"\[([^\]]+)\]\(([^)]+?)(\.?)\)", m => 
        {
            var url = m.Groups[2].Value.TrimEnd('.');
            return $"<a href=\"{url}\" target=\"_blank\" rel=\"noopener noreferrer\">{m.Groups[1].Value}</a>";
        });
        
        // Convert bare URLs (http:// or https://) to HTML <a> tags, but not if already in href attribute, removing trailing period
        text = Regex.Replace(text, @"(?<!href="")(?<!href='')(https?://[^\s<>""{}|\\^`\[\]]*?)(\.?)(?=[\s<>""{}|\\^`\[\]]*$|[\s<>""{}|\\^`\[\]])", m => 
        {
            var url = m.Groups[1].Value.TrimEnd('.');
            return $"<a href=\"{url}\" target=\"_blank\" rel=\"noopener noreferrer\">{url}</a>";
        });
        
        // Sanitize HTML to remove dangerous content while keeping safe links
        var sanitizer = new HtmlSanitizer();
        text = sanitizer.Sanitize(text);
        
        return text;
    }
}
