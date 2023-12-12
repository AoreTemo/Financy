using System.Security.Claims;
using BLL.Interfaces;
using DL.Entities;
using FinancyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancyApp.Controllers;

public class HomeController : Controller
{
    private readonly ICostService _costService;
    private readonly ICategoryService _categoryService;
    private readonly IAppUserService _appUserService;
    
    public HomeController(ICostService costService, ICategoryService categoryService, 
        IAppUserService appUserService)
    {
        _costService = costService;
        _categoryService = categoryService;
        _appUserService = appUserService;
    }
    
    // GET
    public IActionResult Index(HomeViewModel model)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        List<Category> categories = new List<Category>();
        if (userId != null)
        {
            var user = _appUserService.GetById(userId);
            categories = _categoryService.GetByPredicate(c => c.Id == userId);
        }

        

        if (!string.IsNullOrEmpty(model.Search))
        {
            categories = categories.Where(c => c.CategoryName.Contains(model.Search)).ToList();
        }

        if (!string.IsNullOrEmpty(model.Sort))
        {
            if (model.Sort == "asc")
            {
                categories.Sort((c1, c2) => c1.CategoryName.CompareTo(c2.CategoryName));
            }
            else
            {
                categories.Sort((c1, c2) => c2.CategoryName.CompareTo(c1.CategoryName));
            }
        }
        
        var homeViewModel = new HomeViewModel
        {
            Search = model.Search,
            Sort = model.Sort,
            Categories = categories
        };

        return View(homeViewModel);
    }
}