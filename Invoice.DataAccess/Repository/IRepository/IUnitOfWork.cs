using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IInvoiceRepository Invoice { get; }
        IBillRepository Bill { get; }
        IPartyDetailRepository PartyDetail { get; } 
        IBillItemRepository BillItem { get; }
        void Save();
    }
}
