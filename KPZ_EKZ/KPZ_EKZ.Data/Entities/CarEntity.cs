using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.Entities
{
    public class CarEntity : AbstractEntity
    {
        public short Year { get; set; }

        [StringLength(100)]
        public string Model { get; set; }

        [StringLength(100)]
        public string Make { get; set; }
        public virtual ICollection<CarItemEntity> Items { get; set; }
    }
}
