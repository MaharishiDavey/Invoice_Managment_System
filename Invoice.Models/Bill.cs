using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Invoice.Models
{
    public class Bill
    {
        [Key]
        public string BillNo { get; set; }

        // Navigation property to BillItems
        public List<BillItem> BillItems { get; set; }

        public int PartyId { get; set; }

        [ForeignKey("PartyId")]
        [ValidateNever]
        public PartyDetail PartyDetail { get; set; }
    }
}
