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
    public class BrandController : Controller
    {

        BrandServices services = new BrandServices();

        // GET: Admin/Brand
        public ActionResult Index()
        {
            BrandListingModel model = new BrandListingModel();

            model.Brands = services.GetAllBrands();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddAndEdit(int? ID)
        {
            BrandActionModel model = new BrandActionModel();

            if (ID.HasValue)
            {
                var brand = services.GetBrandByID(ID.Value);

                model.BrandID = brand.BrandID;

                model.BrandName = brand.BrandName;

            }

            return PartialView("_AddAndEdit", model);

        }

        [HttpPost]
        public JsonResult AddAndEdit(BrandActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.BrandID > 0)
            {
                var brand = services.GetBrandByID(model.BrandID);

                brand.BrandName = model.BrandName;

                brand.UpdatedAt = DateTime.Now;

                result = services.UpdateBrand(brand);
            }
            else
            {
                Brand brand = new Brand();

                brand.BrandName = model.BrandName;

                brand.UpdatedAt = DateTime.Now;

                result = services.SaveBrand(brand);
            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Main Menu" };
            }

            return json;

        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            BrandActionModel model = new BrandActionModel();

            var brand = services.GetBrandByID(ID);

            model.BrandID = brand.BrandID;

            return PartialView("_Delete", model);

        }

        [HttpPost]
        public JsonResult Delete(BrandActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var brand = services.GetBrandByID(model.BrandID);

            result = services.DeleteBrand(brand);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Main Menu" };
            }

            return json;

        }
    }
}