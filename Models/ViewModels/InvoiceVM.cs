using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class InvoiceVM
    {
        public PartyDetail PartyDetails { get; set; }
        public Bill Bills { get; set; }
    }
}
