﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_EKZ.Data.Entities
{
    public abstract class AbstractEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
