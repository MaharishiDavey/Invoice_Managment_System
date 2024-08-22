using Invoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.DataAccess.Repository.IRepository
{
    public interface IPartyDetailRepository : IRepository<PartyDetail>
    {
        void Update(PartyDetail obj);
    }
}
