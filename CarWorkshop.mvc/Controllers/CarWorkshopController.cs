using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName;
using CarWorkshop.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.mvc.Controllers;

public class CarWorkshopController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public CarWorkshopController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var carWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuery());

        return View(carWorkshops);
    }

    public IActionResult Create()
    {
        return View();
    }
    [Route("CarWorkshop/{encodedName}/Details")]
    public async Task<IActionResult> Details(string encodedName)
    {
        var carWorkshop = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
        return View(carWorkshop);
    }
    [Route("CarWorkshop/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditCarWorkshopCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        var carWorkshop = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
        var model = _mapper.Map<EditCarWorkshopCommand>(carWorkshop);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}