using Invoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.DataAccess.Repository.IRepository
{
    public interface IBillItemRepository : IRepository<BillItem>
    {
        void Update(BillItem obj);
    }
}
