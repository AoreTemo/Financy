using BLL.Interfaces;
using DL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinancyApp.Controllers;

public class CategoryController : Controller
{
    private readonly IGenericService<Category> _categoryService;

    public CategoryController(IGenericService<Category> categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public IActionResult Add(Category category)
    {
        _categoryService.Add(category);
        
        return RedirectToAction("Index", "Costs");
    }
    
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        _categoryService.Update(category);
        
        return RedirectToAction("Index", "Costs");
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _categoryService.Delete(id);
        
        return RedirectToAction("Index", "Costs");
    }
}