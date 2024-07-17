namespace PopularAttributesAIApp.Models;

public class PopularCategory
{
    public int CategoryId { get; set; }
    public IEnumerable<string>? Attributes { get; set; }
}