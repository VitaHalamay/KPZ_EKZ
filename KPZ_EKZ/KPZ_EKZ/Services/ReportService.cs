using KPZ_EKZ.Data.DTOs.Car;
using KPZ_EKZ.Data.DTOs.Seller;
using KPZ_EKZ.Data.Repositories.Interfaces;
using KPZ_EKZ.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPZ_EKZ.Services
{
    public class ReportService : IReportService
    {
        private IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<List<CarSellingDto>> GetReportForCars()
        {
            return await _reportRepository.GetReportForCars();
        }

        public async Task<List<SellerSellingDto>> GetReportForSellers()
        {
            return await _reportRepository.GetReportForSellers();
        }
    }
}
