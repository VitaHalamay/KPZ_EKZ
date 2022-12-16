using KPZ_EKZ.Data.DTOs.Car;
using KPZ_EKZ.Data.DTOs.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<List<CarSellingDto>> GetReportForCars();
        Task<List<SellerSellingDto>> GetReportForSellers();
    }
}
