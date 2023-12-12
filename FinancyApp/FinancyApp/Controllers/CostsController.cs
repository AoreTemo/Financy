using BLL.Interfaces;
using BLL.Services;
using DL.Entities;
using FinancyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace FinancyApp.Controllers;

public class CostsController : Controller
{
    private readonly ICostService _costService;
    private readonly ICategoryService _categoryService;
    private readonly IAppUserService _appUserService;
    public CostsController(ICostService costService, ICategoryService categoryService, 
        IAppUserService appUserService)
    {
        _costService = costService;
        _categoryService = categoryService;
        _appUserService = appUserService;
    }

    [HttpGet]
    public IActionResult Index(CostViewModel costViewModel)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var categories = _categoryService.GetByPredicate(category => category.Id == userId).ToList();
        costViewModel.Category = categories.Select(categories => new SelectListItem
        {
            Value = categories.CategoryId.ToString(),
            Text = categories.CategoryName
        }).ToList();


        return View(costViewModel);
    }

    [HttpPost]
    public IActionResult Add(CostViewModel costViewModel)
    {

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var currentUser = _appUserService.GetById(userId);
        var newCost = new Cost
        {
            CostsDescription = costViewModel.CostDescription,
            CostsDate = costViewModel.CostDate,
            Id = userId,
            Amount = costViewModel.Amount,
            CategoryId = costViewModel.CategoryId,
        };
         _costService.Add(newCost);
         currentUser.Balance -= newCost.Amount;
         if (currentUser.Balance < 0)
         {
             currentUser.Balance = 0;
         }
         _appUserService.Update(currentUser);
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
        var cost = _costService.GetById(id);
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var currentUser = _appUserService.GetById(userId);
        currentUser.Balance += cost.Amount;
        
        _costService.Delete(id);
            
        return RedirectToAction("Index");
    }
}