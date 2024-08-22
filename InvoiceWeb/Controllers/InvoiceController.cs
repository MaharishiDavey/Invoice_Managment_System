using Invoice.DataAccess.Repository.IRepository;
using Invoice.Models;
using Invoice.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            List<InvoiceVM> objInvoiceList = _unitOfWork.Invoice.GetAll().ToList();
            //return View(objInvoiceList);
            Console.WriteLine(objInvoiceList);
            return View();
        }

        public IActionResult Upsert(string? BillNo)
        {

            InvoiceVM invoiceVM = new()
            {
                PartyDetail = new PartyDetail(),
                Bill = new Bill(),
                BillItem = new BillItem()
            };
            if (BillNo == null || BillNo == "")
            {
                //create
                return View(invoiceVM);
            }
            else
            {
                //Update
                invoiceVM.Bill = _unitOfWork.Bill.Get(u => u.BillNo == BillNo);
                invoiceVM.BillItem = _unitOfWork.BillItem.Get(u => u.BillNo == BillNo);
                return View(invoiceVM);
            }

        }
        [HttpPost]
        public IActionResult Upsert(InvoiceVM invoiceVM)
        {
            if (ModelState.IsValid)
            {
                
                if (invoiceVM.Bill.BillNo == "")
                {
                    _unitOfWork.Bill.Add(invoiceVM.Bill);
                    _unitOfWork.BillItem.Add(invoiceVM.BillItem);
                }
                else
                {
                    _unitOfWork.Bill.Update(invoiceVM.Bill);
                    _unitOfWork.BillItem.Update(invoiceVM.BillItem);
                }

                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(invoiceVM);
            }
        }

        //#region Api Call
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        //    return Json(new { data = objProductList });
        //}

        //[HttpDelete]
        //public IActionResult Delete(int? id)
        //{
        //    var productToBeDeleted = _unitOfWork.Product.Get(u => u.Id == id);

        //    if (productToBeDeleted == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }

        //    var oldImagePath =
        //                    Path.Combine(_webHostEnvironment.WebRootPath,
        //                    productToBeDeleted.ImageUrl.TrimStart('\\'));

        //    if (System.IO.File.Exists(oldImagePath))
        //    {
        //        System.IO.File.Delete(oldImagePath);
        //    }

        //    _unitOfWork.Product.Remove(productToBeDeleted);
        //    _unitOfWork.Save();

        //    return Json(new { success = true, message = "Deleted Successfully" });
        //}

        //#endregion

    }
}
