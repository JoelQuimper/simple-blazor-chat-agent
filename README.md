# Blazor Chat Agent

> **⚠️ DISCLAIMER: This is a sample project for demonstration purposes only and is not supported.**

A sample Blazor web application that demonstrates integration with Microsoft AI Foundry Agents for building an interactive chat interface. It is built using the preview Foundry IQ SDK and showcases real-time communication with an AI agent.

## Overview

This project showcases how to build a real-time chat application using:
- **Blazor Server** - Interactive server-side web components
- **Microsoft AI Foundry** - Intelligent agent-based conversational AI
- **C# / .NET 10** - Modern .NET runtime

The application provides a clean, user-friendly chat interface that communicates with an AI agent to handle user queries.

## ⚠️ Important Notice

**This is a SAMPLE PROJECT for educational and demonstration purposes only.** It is:
- **Not officially supported** by Microsoft
- **Not production-ready** without additional security hardening
- **Not recommended** for use in production environments without thorough review and modifications
- Provided "as-is" with no guarantees

## Features

- Real-time chat interface
- Integration with Microsoft AI Foundry agents
- Interactive server-side rendering with Blazor
- Responsive design
- Automatic scrolling to latest messages

## Prerequisites

- .NET 10 SDK or later
- An Azure subscription
- Microsoft AI Foundry project with a configured agent
- Azure CLI (`az`) installed and authenticated

## Setup Instructions

### 1. Clone the Repository
```bash
git clone <repository-url>
cd simple-blazor-chat-agent
```

### 2. Configure Azure Credentials
Authenticate with Azure using the Azure CLI:
```bash
az login
```

### 3. Update Configuration
Edit `src/blazor-chat-agent/appsettings.Development.json` with your Microsoft AI Foundry endpoint and agent name:
```json
{
  "MicrosoftFoundry": {
    "Endpoint": "https://your-endpoint-here/api/projects/your-project",
    "AgentName": "your-agent-name"
  }
}
```

### 4. Build the Project
```bash
cd src/blazor-chat-agent
dotnet build
```

### 5. Run the Application
```bash
dotnet run
```

The application will be available at `https://localhost:7224` (or the port shown in the console).

## Project Structure

```
src/blazor-chat-agent/
├── Components/          # Razor components
│   ├── Pages/          # Page components
│   ├── Layout/         # Layout components
│   └── App.razor       # Root component
├── Models/             # Data models
├── Services/           # Business logic (FoundryService)
├── wwwroot/            # Static assets (CSS, JS)
└── Program.cs          # Application startup
```

## Configuration Files

- `appsettings.json` - Base configuration (commit to repo)
- `appsettings.Development.json` - Local development settings (gitignored - create locally)

## Troubleshooting

### "An unhandled error has occurred" message
- Ensure you are authenticated with Azure: `az login`
- Verify your Azure credentials have access to the configured agent
- Check browser console (F12) for detailed error messages

### Connection Issues
- Verify the endpoint URL in your configuration
- Check that the agent name is correct
- Ensure your Azure subscription is active and has the required permissions

## Security Considerations

**This is a sample application. For production use, consider:**
- Implementing proper authentication and authorization
- Using Azure Key Vault for sensitive configuration
- Adding rate limiting and input validation
- Implementing logging and monitoring
- Adding error handling and graceful degradation
- Securing WebSocket connections
- Implementing CSRF protection

## License

See [LICENSE](LICENSE) file for details.

## Support

**This project is NOT SUPPORTED.** It is provided as a sample for educational purposes only.

For issues or questions about Microsoft AI Foundry, please refer to the [official Microsoft documentation](https://learn.microsoft.com/en-us/azure/ai-studio/).