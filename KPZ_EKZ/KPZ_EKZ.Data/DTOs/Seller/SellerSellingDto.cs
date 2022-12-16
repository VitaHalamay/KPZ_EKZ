using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.DTOs.Seller
{
    public class SellerSellingDto : SellerDto
    {
        public double Commission { get; set; }
        public int Cars { get; set; }
    }
}
