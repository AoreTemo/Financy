using DL.Entities;

namespace FinancyApp.Models;

public class ViewCategoryCostsViewModel
{
    public string? CategoryName { get; set; }
    public string? CategoryColor { get; set; }
    
    public List<Cost>? Costs { get; set; }
}