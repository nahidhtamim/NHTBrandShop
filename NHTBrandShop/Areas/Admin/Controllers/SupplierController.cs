using NHTBrandShop.Areas.Admin.Models;
using NHTBrandShop.Entities;
using NHTBrandShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHTBrandShop.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        SupplierServices services = new SupplierServices();
        // GET: Admin/Supplier
        public ActionResult Index()
        {
            SupplierListingModel model = new SupplierListingModel();

            model.Suppliers = services.GetAllSuppliers();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddAndEdit(int? ID)
        {
            SupplierActionModel model = new SupplierActionModel();

            if (ID.HasValue)
            {
                var suppler = services.GetSupplierByID(ID.Value);

                model.SupplierID = suppler.SupplierID;

                model.SupplierName = suppler.SupplierName;

            }
            return PartialView("_AddAndEdit", model);
        }

        [HttpPost]
        public JsonResult AddAndEdit(SupplierActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.SupplierID > 0)
            {
                var supplier = services.GetSupplierByID(model.SupplierID);

                supplier.SupplierName = model.SupplierName;

                supplier.UpdatedAt = DateTime.Now;

                result = services.UpdateSupplier(supplier);
            }
            else
            {
                Supplier supplier = new Supplier();

                supplier.SupplierName = model.SupplierName;

                supplier.UpdatedAt = DateTime.Now;

                result = services.SaveSupplier(supplier);
            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform any action" };
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            SupplierActionModel model = new SupplierActionModel();

            var mainMenu = services.GetSupplierByID(ID);

            model.SupplierID = mainMenu.SupplierID;

            return PartialView("_Delete", model);

        }

        [HttpPost]
        public JsonResult Delete(SupplierActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var supplier = services.GetSupplierByID(model.SupplierID);

            result = services.DeleteSupplier(supplier);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform any action" };
            }

            return json;
        }
    }
}