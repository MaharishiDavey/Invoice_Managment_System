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
    public class BillItemRepository : Repository<BillItem>, IBillItemRepository
    {
        private readonly ApplicationDbContext _db;
        public BillItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BillItem obj)
        {
            _db.BillItems.Update(obj);

        }
    }
}
