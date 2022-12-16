﻿using KPZ_EKZ.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KPZ_EKZ.Data
{
    public class DataContext : DbContext
{
        public DbSet<CarEntity> Cars { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CarShop;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}