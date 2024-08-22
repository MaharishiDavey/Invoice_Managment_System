using Invoice.DataAccess.Data;
using Invoice.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IInvoiceRepository Invoice { get; private set; }
        public IBillRepository Bill { get; private set; }
        public IPartyDetailRepository PartyDetail { get; private set; }
        public IBillItemRepository BillItem { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Invoice = new InvoiceRepository(_db);
            Bill = new BillRepository(_db);
            PartyDetail = new PartyDetailRepository(_db);
            BillItem = new BillItemRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
