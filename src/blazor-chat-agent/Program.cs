using BlazorChatAgent.Components;
using BlazorChatAgent.Services;

const string FoundryEndpointConfig = "MicrosoftFoundry:Endpoint";
const string FoundryAgentNameConfig = "MicrosoftFoundry:AgentName";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<HtmlProcessingService>();

builder.Services.AddScoped<FoundryService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var logger = provider.GetRequiredService<ILogger<FoundryService>>();
    var endpoint = configuration[FoundryEndpointConfig] ?? throw new InvalidOperationException($"{FoundryEndpointConfig} is not configured");
    var deploymentName = configuration[FoundryAgentNameConfig] ?? throw new InvalidOperationException($"{FoundryAgentNameConfig} is not configured");
    return new FoundryService(endpoint, deploymentName, logger);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
