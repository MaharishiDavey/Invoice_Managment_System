using Invoice.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PartyDetail> PartyDetails { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding PartyDetails
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

            // Seeding Bills
            modelBuilder.Entity<Bill>().HasData(
                new Bill
                {
                    BillNo = "B001",
                    PartyName = "The Bread Basket"
                },
                new Bill
                {
                    BillNo = "B002",
                    PartyName = "Sweet Tooth Supply"
                },
                new Bill
                {
                    BillNo = "B003",
                    PartyName = "Sweet Tooth Supply"
                },
                new Bill
                {
                    BillNo = "B004",
                    PartyName = "The Bread Basket"
                }
            );

            // Seeding BillItems
            modelBuilder.Entity<BillItem>().HasData(
                new BillItem
                {
                    Id = 1,
                    SNO = 1,
                    Particular = "Cake",
                    HSNCode = "21436587",
                    Quantity = 2,
                    Rate = 20,
                    Amount = 40,
                    BillNo = "B001"
                },
                new BillItem
                {
                    Id = 2,
                    SNO = 2,
                    Particular = "Apple Pie",
                    HSNCode = "26843715",
                    Quantity = 1,
                    Rate = 50,
                    Amount = 50,
                    BillNo = "B001"
                },
                new BillItem
                {
                    Id = 3,
                    SNO = 3,
                    Particular = "Cola",
                    HSNCode = "43219876",
                    Quantity = 1,
                    Rate = 40,
                    Amount = 40,
                    BillNo = "B001"
                },
                new BillItem
                {
                    Id = 4,
                    SNO = 1,
                    Particular = "Cake",
                    HSNCode = "21436587",
                    Quantity = 2,
                    Rate = 20,
                    Amount = 40,
                    BillNo = "B002"
                },
                new BillItem
                {
                    Id = 5,
                    SNO = 2,
                    Particular = "Apple Pie",
                    HSNCode = "26843715",
                    Quantity = 1,
                    Rate = 50,
                    Amount = 50,
                    BillNo = "B002"
                },
                new BillItem
                {
                    Id = 6,
                    SNO = 1,
                    Particular = "Cake",
                    HSNCode = "21436587",
                    Quantity = 2,
                    Rate = 20,
                    Amount = 40,
                    BillNo = "B003"
                },
                new BillItem
                {
                    Id = 7,
                    SNO = 2,
                    Particular = "Apple Pie",
                    HSNCode = "26843715",
                    Quantity = 1,
                    Rate = 50,
                    Amount = 50,
                    BillNo = "B003"
                },
                new BillItem
                {
                    Id = 8,
                    SNO = 3,
                    Particular = "Cola",
                    HSNCode = "43219876",
                    Quantity = 1,
                    Rate = 40,
                    Amount = 40,
                    BillNo = "B003"
                },
                new BillItem
                {
                    Id = 9,
                    SNO = 4,
                    Particular = "Ice Cream",
                    HSNCode = "94712586",
                    Quantity = 2,
                    Rate = 15,
                    Amount = 30,
                    BillNo = "B003"
                },
                new BillItem
                {
                    Id = 10,
                    SNO = 1,
                    Particular = "Cake",
                    HSNCode = "21436587",
                    Quantity = 2,
                    Rate = 20,
                    Amount = 40,
                    BillNo = "B004"
                }
            );
        }
    }
}
