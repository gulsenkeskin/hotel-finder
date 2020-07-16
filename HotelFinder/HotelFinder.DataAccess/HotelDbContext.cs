using System;
using System.Collections.Generic;
using System.Text;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess
{
   public class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server= DESKTOP-6TIKNFS; Database=HotelDb;uid=gulsen;pwd=1g6efljs;");

        }
        //business katmanında hotel db class ını eklediğimiz zaman bize hotels diye birproperty gelicek crud işlemlerini yapan methodlara sahip oluruz 
        public DbSet<Hotel> Hotels { get; set; }

    }
}
