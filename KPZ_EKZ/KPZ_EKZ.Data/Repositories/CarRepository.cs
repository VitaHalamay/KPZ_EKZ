using KPZ_EKZ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KPZ_EKZ.Data.Repositories.Interfaces;
using KPZ_EKZ.Data.DTOs.Car;

namespace KPZ_EKZ.Data.Repositories
{
    public class CarRepository : AbstractRepository, ICarRepository
    {
        public CarRepository(DataContext context) : base(context)
        {
        }
        public async Task<List<CarDto>> GetAll()
        {
            var cars = await Context.CarItems
                .Include(ci => ci.Car)
                .Select(ci => new CarDto
                {
                    Id = ci.Id,
                    Year = ci.Car.Year,
                    Model = ci.Car.Model,
                    Make = ci.Car.Make,
                    LicensePlate = ci.LicensePlate,
                    Description = ci.Description,
                    InitialPrice = ci.InitialPrice,
                    ShopCommission = ci.ShopCommission,
                    SellerCommission = ci.SellerCommission,
                    Sold = ci.Sellings.Any()
                })
                .ToListAsync();

            return cars;
        }
        public async Task AddOrUpdate(short year, string make, string model, string licensePlate, string description, double? price)
        {
            var carEntity = await Context.Cars
                .FirstOrDefaultAsync(c => c.Year == year && c.Make == make && c.Model == model);

            if (carEntity == null)
            {
                carEntity = new CarEntity
                {
                    Year = year,
                    Make = make,
                    Model = model
                };
                SetCreated(carEntity);
                await Context.Cars.AddAsync(carEntity);
            }

            var carItemEntity = await Context.CarItems.FirstOrDefaultAsync(ci => ci.LicensePlate == licensePlate);
            if (carItemEntity == null)
            {
                carItemEntity = new CarItemEntity
                {
                    Car = carEntity,
                    LicensePlate = licensePlate,
                    Description = description,
                    InitialPrice = price,
                    ShopCommission = price * 0.15,
                    SellerCommission = price * 0.05
                };
                SetCreated(carItemEntity);
                await Context.CarItems.AddAsync(carItemEntity);
            }
            else
            {
                carItemEntity.Car = carEntity;
                carItemEntity.InitialPrice = price;
                carItemEntity.Description = description;
                carItemEntity.ShopCommission = price * 0.15;
                carItemEntity.SellerCommission = price * 0.05;
                SetUpdated(carItemEntity);
                Context.CarItems.Update(carItemEntity);
            }
        }

        public async Task<CarDto> GetById(int id)
        {
            var car = await Context.CarItems
                   .Include(ci => ci.Car)
                   .Where(ci => ci.CarId == id)
                   .Select(ci => new CarDto
                   {
                       Id = ci.Id,
                       Year = ci.Car.Year,
                       Model = ci.Car.Model,
                       Make = ci.Car.Make,
                       LicensePlate = ci.LicensePlate,
                       Description = ci.Description,
                       InitialPrice = ci.InitialPrice,
                       ShopCommission = ci.ShopCommission,
                       SellerCommission = ci.SellerCommission,
                       Sold = ci.Sellings.Any()
                   })
                   .FirstOrDefaultAsync();

            return car;
        }

        public async Task SellCar(int carItemId, int sellerId)
        {
            var sellingEntity = new SellingEntity
            {
                CarItemId = carItemId,
                SellerId = sellerId
            };
            SetCreated(sellingEntity);
            await Context.Sellings.AddAsync(sellingEntity);
        }
    }
}
