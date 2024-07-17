using ChatGptNet;
using PopularAttributesAIApp.Models;
using ChatGptNet.Extensions;

namespace PopularAttributesAIApp.Services;

public class AttributeService
{
    private readonly IChatGptClient _chatGptClient;

    public AttributeService(IChatGptClient chatGptClient)
    {
        _chatGptClient = chatGptClient;
    }

    public async Task<IReadOnlyCollection<string>?> GetPopularAttributesAsync(SubCategory subCategory)
    {
        var prompt = $"What are the 3 most popular attributes for the category '{subCategory.CategoryName}'?";
        var response = await _chatGptClient.AskAsync(prompt);
        return response.GetContent()?.Split(',').Select(a => a.Trim()).Take(3).ToList();
    }
}

