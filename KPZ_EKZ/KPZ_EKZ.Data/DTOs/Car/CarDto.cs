using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.DTOs.Car
{
    public class CarDto : CarCreateUpdateDto
    {
        public int Id { get; set; }
        public double? ShopCommission { get; set; }
        public double? SellerCommission { get; set; }
        public bool Sold { get; set; }
        public double? TotalPrice
        {
            get
            {
                return InitialPrice + ShopCommission + SellerCommission;
            }
        }
    }
}
