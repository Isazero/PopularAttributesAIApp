namespace PopularAttributesAIApp.Models;

public class Category
{
    public string CategoryName { get; set; }
    public IEnumerable<SubCategory> SubCategories { get; set; }
}
