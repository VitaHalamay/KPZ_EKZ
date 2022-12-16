using KPZ_EKZ.Data;
using KPZ_EKZ.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPZ_EKZ.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void Seed(this IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<DataContext>();

            context.Database.Migrate();

            SeedCars(serviceScope).Wait();
        }

        private static async Task SeedCars(IServiceScope serviceScope)
        {
            var carRepository = serviceScope.ServiceProvider.GetService<ICarRepository>();

            await carRepository.AddOrUpdate(2022, "Mercedes‑Benz", "A‑Class");
            await carRepository.AddOrUpdate(2023, "Audi", "A3");
            await carRepository.AddOrUpdate(2022, "Audi", "A4");
            await carRepository.AddOrUpdate(1922, "Bugatti", "Type 30");
            await carRepository.AddOrUpdate(2020, "Cadillac", "Cimarron");
            await carRepository.AddOrUpdate(2020, "Audi", "A5");
            await carRepository.AddOrUpdate(2020, "Chevrolet", "Malibu");
            await carRepository.AddOrUpdate(2019, "Chevrolet", "Volt");
            await carRepository.AddOrUpdate(2020, "Chevrolet", "Suburban");
            await carRepository.AddOrUpdate(2018, "Chevrolet", "Cruze");
            await carRepository.AddOrUpdate(2018, "Chevrolet", "Camaro");
            await carRepository.AddOrUpdate(2009, "Fiat", "Panda");
            await carRepository.AddOrUpdate(2009, "Fiat", "Punto");
            await carRepository.AddOrUpdate(2009, "Fiat", "Uno");

            await carRepository.SaveChangesAsync();
        }
    }
}
