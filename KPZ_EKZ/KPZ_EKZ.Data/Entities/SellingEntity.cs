using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.Entities
{
    public class SellingEntity : AbstractEntity
    {
        public int CarItemId { get; set; }
        public int SellerId { get; set; }
        public virtual CarItemEntity CarItem { get; set; }
        public virtual SellerEntity Seller { get; set; }
    }
}
