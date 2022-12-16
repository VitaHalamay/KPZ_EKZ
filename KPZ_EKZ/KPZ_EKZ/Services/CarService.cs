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

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public Task<CarDto> CreateCar(CarCreateUpdateDto car)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCar(int carId)
        {
            throw new NotImplementedException();
        }

        public Task<CarDto> GetCar(int carId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CarDto>> GetCars()
        {
            return await _carRepository.GetAll();
        }

        public Task UpdateCar(int carId, CarCreateUpdateDto car)
        {
            throw new NotImplementedException();
        }
    }
}
