using ChatGptNet;
using ChatGptNet.Models;
using ChatGptNet.Models.Embeddings;
using PopularAttributesAIApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddChatGpt(options =>
{
    // OpenAI.
    options.UseOpenAI(apiKey: builder.Configuration["ChatGPT:ApiKey"] ?? throw new InvalidOperationException(),
        organization: "");

    // Azure OpenAI Service.
    //options.UseAzure(resourceName: "", apiKey: "", authenticationType: AzureAuthenticationType.ApiKey);

    options.DefaultModel = OpenAIChatGptModels.Gpt35_Turbo_16k;
    options.DefaultEmbeddingModel = OpenAIEmbeddingModels.TextEmbedding3Small;
    options.MessageLimit = 16; // Default: 10
    options.MessageExpiration = TimeSpan.FromMinutes(5); // Default: 1 hour
    options.DefaultParameters = new ChatGptParameters
    {
        MaxTokens = 800,
        Temperature = 0.7,
        ResponseFormat = ChatGptResponseFormat.Json
    };
});
builder.Services.AddTransient<AttributeService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Category Attribute API",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Category Attribute API V1");
        c.RoutePrefix = string.Empty; 
    });
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();