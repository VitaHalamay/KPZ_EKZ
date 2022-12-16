using KPZ_EKZ.Data.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPZ_EKZ.Services.Interfaces
{
    public interface ICarService
    {
        Task<List<CarDto>> GetCars();
        Task<CarDto> GetCar(int carId);
        Task CreateCar(CarCreateUpdateDto car);
        Task UpdateCar(int carId, CarCreateUpdateDto car);
        Task SellCar(int carId, string code);

    }
}
