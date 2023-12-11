using BLL.Interfaces;
using DL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinancyApp.Controllers;

public class CostsController : Controller
{
    private readonly IGenericService<Cost> _costService;

    public CostsController(IGenericService<Cost> costService)
    {
        _costService = costService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Add(Cost model)
    {
        if (!ModelState.IsValid) return BadRequest("Aboba");
        _costService.Add(model);
            
        return RedirectToAction("Index");
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