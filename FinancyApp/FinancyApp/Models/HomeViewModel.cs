using DL.Entities;

namespace FinancyApp.Models;

public class HomeViewModel
{
    public List<Category>? Categories { get; set; }
    public string? Search { get; set; }
    public string Sort { get; set; } 
}