﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.DTOs.Car
{
    public class CarDto
    {
        public int Id { get; set; }
        public short Year { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string LicensePlate { get; set; }
        public string Description { get; set; }
        public double? InitialPrice { get; set; }
        public double? ShopCommission { get; set; }
        public double? SellerCommission { get; set; }

        public double? TotalPrice
        {
            get
            {
                return InitialPrice + ShopCommission + SellerCommission;
            }
        }
    }
}
