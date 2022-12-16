using KPZ_EKZ.Data.DTOs.Car;
using KPZ_EKZ.Data.DTOs.Seller;
using KPZ_EKZ.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.Repositories
{
    public class ReportRepository : AbstractRepository, IReportRepository
    {
        public ReportRepository(DataContext context) : base(context)
        {
        }
        public async Task<List<CarSellingDto>> GetReportForCars()
        {
            var cars = await Context.CarItems
                .Include(ci => ci.Car)
                .Where(ci => ci.Sellings.Any())
                .Select(ci => new CarSellingDto
                {
                    Id = ci.Id,
                    Year = ci.Car.Year,
                    Model = ci.Car.Model,
                    Make = ci.Car.Make,
                    LicensePlate = ci.LicensePlate,
                    InitialPrice = ci.InitialPrice,
                    ShopCommission = ci.ShopCommission,
                    SellerCommission = ci.SellerCommission,
                    FirstName = ci.Sellings.First().Seller.FirstName,
                    LastName = ci.Sellings.First().Seller.LastName,
                    SoldAt = ci.Sellings.First().Created,
                    Sold = true
                })
                .ToListAsync();

            return cars;
        }
        public async Task<List<SellerSellingDto>> GetReportForSellers()
        {
            var sellers = await Context.Sellers
                .Select(s => new SellerSellingDto
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Cars = s.Sellings.Count,
                    Commission = s.Sellings.Sum(ss => ss.CarItem.SellerCommission) ?? 0
                })
                .ToListAsync();

            return sellers;
        }
    }
}
