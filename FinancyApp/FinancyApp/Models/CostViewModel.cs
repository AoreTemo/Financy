using DL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FinancyApp.Models;

public class CostViewModel
{
    [Required(ErrorMessage ="CostName is required")]
    public string CostDescription { get; set; }

    [Required(ErrorMessage = "CostName is required")]
    public int Amount { get; set; }

    [Required(ErrorMessage = "CostName is required")]
    [DataType(DataType.DateTime)]
    public DateTime CostDate{ get; set; }

    public List<SelectListItem> Category { get; set; }

}
