using KPZ_EKZ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KPZ_EKZ.Data.Repositories.Interfaces;

namespace KPZ_EKZ.Data.Repositories
{
    public class CarRepository : AbstractRepository, ICarRepository
    {
        public CarRepository(DataContext context) : base(context)
        {
        }
        public async Task AddOrUpdate(short year, string make, string model)
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
            else
            {
                SetUpdated(carEntity);
                Context.Cars.Update(carEntity);
            }
        }
    }
}
