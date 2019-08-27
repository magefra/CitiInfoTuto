﻿using Microsoft.EntityFrameworkCore;

namespace CityInfo.Entities
{
    public class CityInfoContext : DbContext
    {

        public CityInfoContext(DbContextOptions<CityInfoContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<PointOfInterest> PointOfinterest { get; set; }
    }
}
