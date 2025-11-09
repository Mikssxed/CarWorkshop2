using CarWorkshop.Domain.Entities;
using CarWorkshop.Infrastructure.Persistence;

namespace CarWorkshop.Infrastructure.Seeders;

public class CarWorkshopSeeder
{
    private readonly CarWorkshopDbContext _dbContext;
    public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Seed()
    {
        if (await _dbContext.Database.CanConnectAsync())
        {
            if (!_dbContext.CarWorkshops.Any())
            {
                var mazdaAso = new Domain.Entities.CarWorkshop()
                {
                   Name = "Mazda ASO",
                   Description = "Mazda ASO",
                   ContactDetails = new CarWorkshopContactDetails()
                   {
                       PhoneNumber = "123456789",
                       Street = "Mazda Street 1",
                       City = "Warsaw",
                       PostalCode = "00-001"
                   }
                };

                mazdaAso.EncodeName();
                _dbContext.CarWorkshops.Add(mazdaAso);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}