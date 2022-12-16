using KPZ_EKZ.Data.DTOs.Car;
using KPZ_EKZ.Data.Repositories.Interfaces;
using KPZ_EKZ.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPZ_EKZ.Services
{
    public class CarService : ICarService
    {
        private ICarRepository _carRepository;
        private ISellerRepository _sellerRepository;

        public CarService(ICarRepository carRepository, ISellerRepository sellerRepository)
        {
            _carRepository = carRepository;
            _sellerRepository = sellerRepository;
        }
        public async Task CreateCar(CarCreateUpdateDto car)
        {
            await _carRepository.AddOrUpdate(car.Year, car.Make, car.Model, car.LicensePlate, car.Description, car.InitialPrice);
            await _carRepository.SaveChangesAsync();
        }

        public Task<CarDto> GetCar(int carId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CarDto>> GetCars()
        {
            return await _carRepository.GetAll();
        }

        public async Task UpdateCar(int carId, CarCreateUpdateDto car)
        {
            await _carRepository.AddOrUpdate(car.Year, car.Make, car.Model, car.LicensePlate, car.Description, car.InitialPrice);
            await _carRepository.SaveChangesAsync();
        }
        public async Task SellCar(int carId, string code)
        {
            var car = await _carRepository.GetById(carId);
            var seller = await _sellerRepository.GetByAccessCode(code);
            await _carRepository.SellCar(car.Id, seller.Id);
            await _carRepository.SaveChangesAsync();
        }
    }
}
