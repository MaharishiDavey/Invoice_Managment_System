using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Invoice.Models.ViewModels
{
    public class InvoiceVM
    {
        public Bill BillModel { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> PartyNameList { get; set; }

        public InvoiceVM()
        {
            BillModel = new Bill();
            BillModel.BillItems = new List<BillItem>(); // Initialize BillItems to an empty list
        }
    }
}
