using System.Text.RegularExpressions;
using Ganss.Xss;

namespace BlazorChatAgent.Services;

public class HtmlProcessingService
{
    public string ConvertMarkdownLinksToHtml(string text)
    {
        // Convert markdown links [text](url) to HTML <a> tags
        text = Regex.Replace(text, @"\[([^\]]+)\]\(([^)]+)\)", "<a href=\"$2\" target=\"_blank\" rel=\"noopener noreferrer\">$1</a>");
        
        // Convert bare URLs (http:// or https://) to HTML <a> tags, but not if already in href attribute
        text = Regex.Replace(text, @"(?<!href="")(?<!href='')(https?://[^\s<>""{}|\\^`\[\]]*)", "<a href=\"$1\" target=\"_blank\" rel=\"noopener noreferrer\">$1</a>");
        
        // Sanitize HTML to remove dangerous content while keeping safe links
        var sanitizer = new HtmlSanitizer();
        text = sanitizer.Sanitize(text);
        
        return text;
    }
}
