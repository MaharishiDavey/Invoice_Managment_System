using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Invoice.Models
{
    public class Bill
    {
        [Key]
        public string BillNo { get; set; }
        public List<int> SNO { get; set; }
        public List<string> Particulars { get; set; }
        public List<string> HSNCode { get; set; }
        public List<int> Quantity { get; set; }
        public List<double> Rate { get; set; }
        public List<double> Amount { get; set; }

        public string PartyName { get; set; }
        [ForeignKey("PartyName")]
        [ValidateNever]
        public PartyDetail PartyDetail { get; set; }
    }
}
