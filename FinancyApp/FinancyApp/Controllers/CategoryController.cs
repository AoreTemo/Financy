using System.Security.Claims;
using BLL.Interfaces;
using DL.Entities;
using FinancyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancyApp.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly ICostService _costsService;
    public CategoryController(ICategoryService categoryService,ICostService costsService)
    {
        _categoryService = categoryService;
        _costsService = costsService;
    }
    
    [HttpGet]
    public IActionResult Info(CategoryViewModel model)
    {
        var categories = _categoryService.GetByPredicate(
            c => c.Id == User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

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
        
        var categoryViewModel = new CategoryViewModel
        {
            Search = model.Search,
            Sort = model.Sort,
            Categories = categories
        };

        return View(categoryViewModel);
    }
    

    
    [HttpPost]
    public IActionResult Add(CategoryViewModel category)
    {
        var newCategory = new Category
        {
            CategoryName = category.CategoryName,
            CategoryColor = category.CategoryColor,
            Id = User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        };
        
        _categoryService.Add(newCategory);
        
        return RedirectToAction("Info");
    }
    
    [HttpPost]
    public IActionResult Edit(int id, 
        string? categoryName = null, 
        string? categoryColor = null)
    {
        var prevCategory = _categoryService.GetById(id);
    
        if (prevCategory != null)
        {
            prevCategory.CategoryName = categoryName ?? prevCategory.CategoryName;
            prevCategory.CategoryColor = categoryColor ?? prevCategory.CategoryColor;
            _categoryService.Update(prevCategory);
        }
    
        return RedirectToAction("Info");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        _categoryService.Delete(id);
        
        return RedirectToAction("Info");
    }

    [HttpGet]
    public IActionResult ViewCategoryCosts(int id)
    {
        var currCategory = _categoryService.GetById(id);
        var costs = _costsService.GetByPredicate(
                c => c.CategoryId == currCategory.CategoryId
            );
        var model = new ViewCategoryCostsViewModel
        {
            CategoryName = currCategory.CategoryName,
            CategoryColor = currCategory.CategoryColor,
            Costs = costs
        };

        return View(model);
    }
}