using Invoice.DataAccess.Data;
using Invoice.DataAccess.Repository.IRepository;
using Invoice.Models;
using Invoice.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.DataAccess.Repository
{
    public class BillRepository : Repository<Bill>, IBillRepository
    {
        private readonly ApplicationDbContext _db;
        public BillRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Bill obj)
        {
            _db.Bills.Update(obj);
        }
    }
}
