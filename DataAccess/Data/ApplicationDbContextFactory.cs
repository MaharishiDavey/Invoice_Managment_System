using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    { 
            public ApplicationDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
                optionsBuilder.UseSqlServer("Server=DESKTOP-QFTO3HU\\APP;Database=Invoice;Trusted_Connection=True;TrustServerCertificate=True");

                return new ApplicationDBContext(optionsBuilder.Options);
            }
        

    }
}
