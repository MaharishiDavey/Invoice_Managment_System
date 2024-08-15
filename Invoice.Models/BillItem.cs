using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Models
{
    public class BillItem
    {
        [Key]
        public int Id { get; set; }

        public int SNO { get; set; }

        public string Particular { get; set; }

        public string HSNCode { get; set; }

        public int Quantity { get; set; }

        public double Rate { get; set; }

        public double Amount { get; set; }

        // Foreign key to Bill
        public string BillNo { get; set; }

        [ForeignKey("BillNo")]
        public Bill Bill { get; set; }
    }
}
