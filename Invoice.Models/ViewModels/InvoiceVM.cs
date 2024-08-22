using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Models.ViewModels
{
    public class InvoiceVM
    {
        public PartyDetail PartyDetail { get; set; }
        public Bill Bill { get; set; }
        public BillItem BillItem { get; set; }
    }
}
