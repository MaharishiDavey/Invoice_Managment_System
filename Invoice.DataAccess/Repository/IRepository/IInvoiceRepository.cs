using Invoice.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.DataAccess.Repository.IRepository
{
    public interface IInvoiceRepository : IRepository<InvoiceVM>
    {
        void Update(InvoiceVM obj);
    }
}
