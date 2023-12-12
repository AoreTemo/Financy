using DL.Entities;

namespace FinancyApp.Models;

public class CategoryViewModel
{
    public string? CategoryName { get; set; }
    public string? CategoryColor { get; set; }
    public string? Search { get; set; }
    public string Sort { get; set; }
    
    public List<Category>? Categories { get; set; }
}