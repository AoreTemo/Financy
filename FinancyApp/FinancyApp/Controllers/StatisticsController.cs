using System.Security.Claims;
using BLL.Interfaces;
using FinancyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancyApp.Controllers;

public class StatisticsController : Controller
{
    private readonly ICostService _costService;
    private readonly ICategoryService _categoryService;
    private readonly IAppUserService _appUserService;

    public StatisticsController(ICostService costService, ICategoryService categoryService, IAppUserService appUserService)
    {
        _costService = costService;
        _categoryService = categoryService;
        _appUserService = appUserService;
    }

    public IActionResult Index()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var currUser = _appUserService.GetById(userId);
        
        var costs = _costService.GetByPredicate(
            c => c.Id == userId
        );
        var categories = _categoryService.GetByPredicate(
            c => c.Id == userId
        );
        
        var model = new StatsViewModel
        {
            Costs = costs,
            Categories = categories,
            Balance = currUser.Balance
        };
        
        return View(model);
    }
}