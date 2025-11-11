using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories;

public class CarWorkshopRepository : ICarWorkshopRepository
{
    private readonly CarWorkshopDbContext _dbContext;
    public CarWorkshopRepository(CarWorkshopDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
    {
        _dbContext.Add(carWorkshop);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Domain.Entities.CarWorkshop?> GetByName(string name)
    {
        var exists = await _dbContext.CarWorkshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
        return exists;
    }

    public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll()
    {
        var carWorkshops = await _dbContext.CarWorkshops.ToListAsync();
        return carWorkshops;
    }
}