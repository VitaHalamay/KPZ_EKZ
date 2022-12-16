using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.DTOs.Car
{
    public class CarSellingDto : CarDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SoldAt { get; set; }
    }
}
