using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Services;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.mvc.Controllers;

public class CarWorkshopController : Controller
{
    private readonly ICarWorkshopService _carWorkshopService;
    
    public CarWorkshopController(ICarWorkshopService carWorkshopService)
    {
        _carWorkshopService = carWorkshopService;
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CarWorkshopDto carWorkshop)
    {
        await _carWorkshopService.Create(carWorkshop);
        return RedirectToAction(nameof(Create));
    }
}