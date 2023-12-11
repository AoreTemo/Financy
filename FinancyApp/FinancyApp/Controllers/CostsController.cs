using BLL.Interfaces;
using BLL.Services;
using DL.Entities;
using FinancyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace FinancyApp.Controllers;

public class CostsController : Controller
{
    private readonly CostService _costService;

    public CostsController(CostService costService)
    {
        _costService = costService;
    }

    [HttpGet]
    public IActionResult Index(CostViewModel costViewModel)
    {
        //var categories = 
        return View();
    }

    [HttpPost]
    public IActionResult Add(CostViewModel costViewModel)
    {

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var categoryId = 1;

        var newCost = new Cost
        {
            CostsDescription = costViewModel.CostDescription,
            CostsDate = costViewModel.CostDate,
            Id = userId,
            Amount = costViewModel.Amount,
            CategoryId = categoryId,
        };
         _costService.Add(newCost);

        return RedirectToAction("Index","Home");
    }
    
    public IActionResult Update(Cost model)
    {
        if (!ModelState.IsValid) return BadRequest("Aboba");
        _costService.Update(model);
            
        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(int id)
    {
        if (!ModelState.IsValid) return BadRequest("Aboba");
        _costService.Delete(id);
            
        return RedirectToAction("Index");
    }
}