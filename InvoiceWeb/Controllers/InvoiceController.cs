using Invoice.DataAccess.Repository.IRepository;
using Invoice.Models;
using Invoice.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InvoiceWeb.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IActionResult Index()
        {
            List<Bill> objInvoiceList = _unitOfWork.Bill.GetAll(includeProperties: "PartyDetail").ToList();
            Console.WriteLine(objInvoiceList);
            return View(objInvoiceList);
        }

        public IActionResult Upsert(string? billNo)
        {
            InvoiceVM invoiceVM = new()
            {
                PartyNameList = _unitOfWork.PartyDetail.GetAll().Select(u => new SelectListItem
                {
                    Text = u.PartyName,
                    Value = u.Id.ToString()
                }).ToList(),

                BillModel = new Bill()
            };

            if (string.IsNullOrEmpty(billNo))
            {
                // Create a new Bill
                invoiceVM.BillModel.BillItems = new List<BillItem>{
                    new BillItem() // Initialize with at least one BillItem if needed
                };
                return View(invoiceVM);
            }
            else
            {
                // Update existing Bill
                invoiceVM.BillModel = _unitOfWork.Bill.Get(
                    u => u.BillNo == billNo,
                    includeProperties: "BillItems"
                );

                if (invoiceVM.BillModel == null)
                {
                    return NotFound();
                }

                // Ensure BillItems list is not null to avoid null reference issues
                if (invoiceVM.BillModel.BillItems == null)
                {
                    invoiceVM.BillModel.BillItems = new List<BillItem>{
                        new BillItem() // Initialize with at least one BillItem if needed
                    };
                }

                return View(invoiceVM);
            }
        }


        [HttpPost]
        public IActionResult Upsert(InvoiceVM invoiceVM)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(invoiceVM.BillModel.BillNo))
                {
                    // Create new Bill
                    _unitOfWork.Bill.Add(invoiceVM.BillModel);
                }
                else
                {
                    // Update existing Bill
                    var existingBill = _unitOfWork.Bill.Get(u => u.BillNo == invoiceVM.BillModel.BillNo);
                    existingBill.PartyId = invoiceVM.BillModel.PartyId;
                    existingBill.BillItems = invoiceVM.BillModel.BillItems;
                    _unitOfWork.Bill.Update(existingBill);
                }

                _unitOfWork.Save();
                TempData["success"] = "Bill saved successfully";
                return RedirectToAction("Index");
            }
            else
            {
                invoiceVM.PartyNameList = _unitOfWork.PartyDetail.GetAll().Select(u => new SelectListItem
                {
                    Text = u.PartyName,
                    Value = u.Id.ToString()
                }).ToList();

                return View(invoiceVM);
            }
        }


        #region Api Call
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Bill> objBillList = _unitOfWork.Bill.GetAll(includeProperties: "PartyDetail").ToList();
            return Json(new { data = objBillList });
        }

        [HttpDelete]
        public IActionResult Delete(string? BillNo)
        {
            var BillToBeDeleted = _unitOfWork.Bill.Get(u => u.BillNo == BillNo);

            if (BillToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Bill.Remove(BillToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successfully" });
        }

        #endregion

    }
}
