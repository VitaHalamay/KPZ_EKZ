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
            SeedSellers(serviceScope).Wait();
        }

        private static async Task SeedCars(IServiceScope serviceScope)
        {
            var carRepository = serviceScope.ServiceProvider.GetService<ICarRepository>();

            await carRepository.AddOrUpdate(2022, "Mercedes‑Benz", "A‑Class", "BC4325AK", "color: black", 23_000);
            await carRepository.AddOrUpdate(2023, "Audi", "A3", "BC4325FK", "color: black", 19_000);
            await carRepository.AddOrUpdate(2022, "Audi", "A4", "BC4325AL", "color: black", 30_000);
            await carRepository.AddOrUpdate(1922, "Bugatti", "Type 30", "BC4325HK", "color: black", 100_000);
            await carRepository.AddOrUpdate(2020, "Cadillac", "Cimarron", "BC4325DK", "color: black", 60_000);
            await carRepository.AddOrUpdate(2020, "Audi", "A5", "BC4325LK", "color: black", 10_000);
            await carRepository.AddOrUpdate(2020, "Chevrolet", "Malibu", "BC4376AK", "color: black", 10_000);
            await carRepository.AddOrUpdate(2019, "Chevrolet", "Volt", "BC6725AK", "color: black", 9_000);
            await carRepository.AddOrUpdate(2020, "Chevrolet", "Suburban", "BC5425AK", "color: black", 10_000);
            await carRepository.AddOrUpdate(2018, "Chevrolet", "Cruze", "BC4395HK", "color: black", 10_000);
            await carRepository.AddOrUpdate(2018, "Chevrolet", "Camaro", "BC5345AG", "color: black", 16_000);
            await carRepository.AddOrUpdate(2009, "Fiat", "Panda", "BC1225AK", "color: black", 11_000);
            await carRepository.AddOrUpdate(2009, "Fiat", "Punto", "BC4327AL", "color: black", 12_000);
            await carRepository.AddOrUpdate(2009, "Fiat", "Uno", "BC1825HK", "color: black", 15_000);

            await carRepository.SaveChangesAsync();
        }
        private static async Task SeedSellers(IServiceScope serviceScope)
        {
            var sellerRepository = serviceScope.ServiceProvider.GetService<ISellerRepository>();

            await sellerRepository.AddOrUpdate("Vita", "Halamay","vitka@gmail.com","380935123432", "VITAH432");
            await sellerRepository.AddOrUpdate("Oleh", "Ivanenko","ivanenko@gmail.com","380935165472", "OLEHI472");
            await sellerRepository.AddOrUpdate("Petro", "Petrenko","petrenko@gmail.com","380636893732", "PETRP732");
            await sellerRepository.AddOrUpdate("Oksana", "Shevchenko","shecvch@gmail.com","380638343792", "OKSAS792");

            await sellerRepository.SaveChangesAsync();
        }
    }
}
