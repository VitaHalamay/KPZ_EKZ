using KPZ_EKZ.Data.DTOs.Car;
using KPZ_EKZ.Data.DTOs.Seller;
using KPZ_EKZ.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPZ_EKZ.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportController
    {
        private IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("car")]
        public async Task<List<CarSellingDto>> GetCars()
        {
            return await _reportService.GetReportForCars();
        }
        [HttpGet("seller")]
        public async Task<List<SellerSellingDto>> GetSellers()
        {
            return await _reportService.GetReportForSellers();
        }
    }
}
