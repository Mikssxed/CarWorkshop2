using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services;

public class CarWorkshopService : ICarWorkshopService
{
    private readonly IMapper _mapper;
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _mapper = mapper;
    }
    public async Task Create(CarWorkshopDto carWorkshopDto)
    {
        var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);
        
        carWorkshop.EncodeName();
        await _carWorkshopRepository.Create(carWorkshop);
    }
}