using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBillRepository Bill { get; }
        IPartyDetailRepository PartyDetail { get; } 
        void Save();
    }
}
