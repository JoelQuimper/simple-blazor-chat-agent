using Azure.AI.Projects;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using BlazorChatAgent.Models;

namespace BlazorChatAgent.Services;

public class FoundryService
{
    private readonly AIProjectClient projectClient;
    private readonly AgentRecord agentRecord;
    private readonly ProjectResponsesClient responseClient;
    private readonly AgentConversation conversation;
    private readonly ILogger<FoundryService> logger;

    public FoundryService(string endpoint, string agentName, ILogger<FoundryService> logger)
    {
        this.logger = logger;
        projectClient = new AIProjectClient(endpoint: new Uri(endpoint), tokenProvider: new DefaultAzureCredential());
        agentRecord = projectClient.Agents.GetAgent(agentName);
        conversation = new AgentConversation();
        responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentRecord);
        logger.LogInformation("Agent retrieved (name: {AgentRecordName}, id: {AgentRecordId})", agentRecord.Name, agentRecord.Id);
    }

    public async Task<string> GetResponseAsync(string prompt)
    {
        // Add user message to conversation history
        conversation.AddUserMessage(prompt);

        // Get the id of the last assistant message to maintain context
        string? lastAssistantMessageId = conversation.Messages
            .Where(m => m.Role == "assistant" && !string.IsNullOrEmpty(m.Id))
            .Select(m => m.Id)
            .LastOrDefault();

        logger.LogInformation("Creating response for prompt. Last assistant message ID: {LastAssistantMessageId}", lastAssistantMessageId ?? "null");

        // Use the agent to generate a response
        var response = lastAssistantMessageId != null
            ? await responseClient.CreateResponseAsync(prompt, lastAssistantMessageId)
            : await responseClient.CreateResponseAsync(prompt);
        
        var assistantResponse = response.Value.GetOutputText();
        logger.LogDebug("Assistant response generated: {AssistantResponse}", assistantResponse);
        
        // Add assistant message to conversation history
        conversation.AddAssistantMessage(assistantResponse, response.Value.Id);

        return assistantResponse;
    }
}
