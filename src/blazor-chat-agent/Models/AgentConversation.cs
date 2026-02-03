namespace BlazorChatAgent.Models;

public class AgentConversation
{
    public List<ConversationMessage> Messages { get; set; } = new();

    public void AddUserMessage(string content)
    {
        Messages.Add(new ConversationMessage
        {
            Id = string.Empty,
            Role = "user",
            Content = content
        });
    }

    public void AddAssistantMessage(string content, string id = "")
    {
        Messages.Add(new ConversationMessage
        {
            Id = id ?? string.Empty,
            Role = "assistant",
            Content = content
        });
    }

    public class ConversationMessage
    {
        public string Id { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
