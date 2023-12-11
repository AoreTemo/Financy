using System.Security.Claims;
using BLL.Interfaces;
using DL.Entities;
using FinancyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancyApp.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IGenericService<Cost> _costsService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public IActionResult Info()
    {
        var categoryViewModel = new CategoryViewModel
        {
            Categories = _categoryService.GetByPredicate(
                c => c.Id == User.FindFirst(ClaimTypes.NameIdentifier)!.Value)
        };

        return View(categoryViewModel);
    }

    [HttpPost]
    public IActionResult Add(Category category)
    {
        var newCategory = new Category
        {
            CategoryName = category.CategoryName,
            CategoryColor = category.CategoryColor,
            Id = User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        };
        
        _categoryService.Add(newCategory);
        
        return RedirectToAction("Index", "Costs");
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
    
    [HttpPost]
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