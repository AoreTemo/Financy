using DL.Entities;

namespace FinancyApp.Models;

public class StatsViewModel
{
    public List<Cost> Costs { get; set; }
    public List<Category> Categories { get; set; }
    public int Balance { get; set; }
}