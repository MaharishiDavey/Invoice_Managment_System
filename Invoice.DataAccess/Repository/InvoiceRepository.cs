using Invoice.DataAccess.Data;
using Invoice.DataAccess.Repository.IRepository;
using Invoice.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.DataAccess.Repository
{
    public class InvoiceRepository : Repository<InvoiceVM>, IInvoiceRepository
    {
        private readonly ApplicationDbContext _db;
        public InvoiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(InvoiceVM obj)
        {
            _db.PartyDetails.Update(obj.PartyDetail);
            _db.Bills.Update(obj.Bill);
            _db.BillItems.Update(obj.BillItem);

        }
    }
}
