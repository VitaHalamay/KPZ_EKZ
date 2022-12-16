using KPZ_EKZ.Data.DTOs.Car;
using KPZ_EKZ.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPZ_EKZ.Controllers
{

    [ApiController]
    [Route("api")]
    public class CarController : ControllerBase
    {
        private ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        /// <summary>
        ///Get cars 
        /// </summary>
        /// <returns></returns>
        [HttpGet("car")]
        public async Task<List<CarDto>> GetCars()
        {
            return await _carService.GetCars();
        }

        /// <summary>
        /// Create car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost("car")]
        public async Task CreateCar([FromBody] CarCreateUpdateDto car)
        {
            await _carService.CreateCar(car);
        }

        /// <summary>
        /// Get car by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("car/{id}")]
        public async Task<CarDto> GetCar(int id)
        {
            return await _carService.GetCar(id);
        }

        /// <summary>
        /// Update car
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPut("car/{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] CarCreateUpdateDto car)
        {
            await _carService.UpdateCar(id, car);
            return Ok();
        }

       
        [HttpPost("car/{id}/sell/{code}")]
        public async Task SellCar(int id, string code)
        {
            await _carService.SellCar(id, code);
        }

    }

}
