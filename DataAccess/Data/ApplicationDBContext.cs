using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
            
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<PartyDetail> partyDetails { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartyDetail>().HasData(
                new PartyDetail
                {
                    PartyName = "Sweet Tooth Supply",
                    Address = "1234 Maple Street, Anytown, CA, 12345, USA",
                    GSTNumber = "27ABACB5678H1Z5"
                },
                new PartyDetail
                {
                    PartyName = "The Bread Basket",
                    Address = "5678 Oak Avenue, Springfield, NY, 54321, USA",
                    GSTNumber = "36AAAC0001AB1Z5"
                }
                );

            modelBuilder.Entity<Bill>().HasData(
                new Bill
                {
                    BillNo = "B001",
                    SNO = { 1, 2, 3 },
                    Particulars = { "Cake", "Apple Pie", "Cola" },
                    HSNCode = { "21436587", "26843715", "43219876" },
                    Quantity = { 2, 1, 1 },
                    Rate = { 20, 50, 40 },
                    Amount = { 40, 50, 40 },
                    PartyName = "The Bread Basket"
                },
                new Bill
                {
                    BillNo = "B002",
                    SNO = { 1, 2 },
                    Particulars = { "Cake", "Apple Pie" },
                    HSNCode = { "21436587", "26843715" },
                    Quantity = { 2, 1 },
                    Rate = { 20, 50 },
                    Amount = { 40, 50 },
                    PartyName = "Sweet Tooth Supply"
                },
                new Bill
                {
                    BillNo = "B003",
                    SNO = { 1, 2, 3, 4 },
                    Particulars = { "Cake", "Apple Pie", "Cola", "ICe Cream" },
                    HSNCode = { "21436587", "26843715", "43219876", "94712586" },
                    Quantity = { 2, 1, 1, 2 },
                    Rate = { 20, 50, 40, 15 },
                    Amount = { 40, 50, 40, 30 },
                    PartyName = "Sweet Tooth Supply"
                },
                new Bill
                {
                    BillNo = "B004",
                    SNO = { 1 },
                    Particulars = { "Cake" },
                    HSNCode = { "21436587" },
                    Quantity = { 2 },
                    Rate = { 20 },
                    Amount = { 40 },
                    PartyName = "The Bread Basket"

                }
                );
        }
    }

   
}
