using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.Entities
{
    public class CarItemEntity : AbstractEntity
    {
        [StringLength(10)]
        public string LicensePlate { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }
        public double? InitialPrice { get; set; }
        public double? ShopCommission { get; set; }
        public double? SellerCommission { get; set; }
        public int CarId { get; set; }
        public virtual CarEntity Car { get; set; }

        
    }
}
