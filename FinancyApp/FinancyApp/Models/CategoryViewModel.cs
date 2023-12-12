using DL.Entities;

namespace FinancyApp.Models;

public class CategoryViewModel
{
    public string? CategoryName { get; set; }
    public string? CategoryColor { get; set; }
    public string? Search { get; set; }
    public bool Sort { get; set; } = false;
    
    public List<Category>? Categories { get; set; }
}