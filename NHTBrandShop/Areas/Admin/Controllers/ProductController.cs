using NHTBrandShop.Areas.Admin.Models;
using NHTBrandShop.DB;
using NHTBrandShop.Entities;
using NHTBrandShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHTBrandShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        MainMenuServices mainServices = new MainMenuServices();

        SubMenuServices subServices = new SubMenuServices();

        TagServices tagServices = new TagServices();

        SupplierServices supplierServices = new SupplierServices();

        ProductServices productServices = new ProductServices();

        // GET: Admin/Product
        
        public ActionResult Index()
        {
            ProductsListingModel model = new ProductsListingModel();

            model.Products = productServices.GetAllProducts();

            model.MainMenus = mainServices.GetAllMainMenus();

            model.SubMenus = subServices.GetAllSubMenus();

            model.Tags = tagServices.GetAllTags();

            model.Suppliers = supplierServices.GetAllSuppliers();

            return View(model);

        }
        
        [HttpGet]
        public ActionResult AddAndEdit(int? ID)
        {
            ProductsActionModel model = new ProductsActionModel();

            if (ID.HasValue)
            {
                var product = productServices.GetProductByID(ID.Value);

                model.ProductID = product.ProductID;
                model.MainMenuID = product.MainMenuID;
                model.SubMenuID = product.SubMenuID;
                model.ProductName = product.ProductName;
                model.ProductCode = product.ProductCode;
                model.BuyingPrice = product.BuyingPrice;
                model.RegularPrice = product.RegularPrice;
                model.DiscountPrice = product.DiscountPrice;
                model.ProductQuantity = product.ProductQuantity;
                model.Color = product.Color;
                model.Config = product.Config;
                model.Description = product.Description;
                model.ProductStatus = product.ProductStatus;
                model.SupplierID = product.SupplierID;
                model.TagID = product.TagID;
            }

            var context = new BrandShopContext();

            List<MainMenu> MainMenuList = context.MainMenus.ToList();

            ViewBag.MainMenuList = new SelectList(MainMenuList, "MainMenuID", "MainMenuName");

            model.MainMenus = mainServices.GetAllMainMenus();

            model.SubMenus = subServices.GetSubMenuByMainMenu(model.MainMenuID);

            model.Tags = tagServices.GetAllTags();

            model.Suppliers = supplierServices.GetAllSuppliers();

            return PartialView("_AddAndEdit", model);

        }

        [HttpPost]
        public JsonResult AddAndEdit(ProductsActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.ProductID > 0)
            {
                var product = productServices.GetProductByID(model.ProductID);

                product.MainMenuID = model.MainMenuID;
                product.SubMenuID = model.SubMenuID;
                product.ProductName = model.ProductName;
                product.ProductCode = model.ProductCode;
                product.BuyingPrice = model.BuyingPrice;
                product.RegularPrice = model.RegularPrice;
                product.DiscountPrice = model.DiscountPrice;
                product.ProductQuantity = model.ProductQuantity;
                product.Color = model.Color;
                product.Config = model.Config;
                product.Description = model.Description;
                product.ProductStatus = model.ProductStatus;
                product.TagID = model.TagID;
                product.SupplierID = model.SupplierID;
                product.UpdatedAt = DateTime.Now;

                result = productServices.UpdateProduct(product);
            }
            else
            {
                Product product = new Product();

                product.MainMenuID = model.MainMenuID;
                product.SubMenuID = model.SubMenuID;
                product.ProductName = model.ProductName;
                product.ProductCode = model.ProductCode;
                product.BuyingPrice = model.BuyingPrice;
                product.RegularPrice = model.RegularPrice;
                product.DiscountPrice = model.DiscountPrice;
                product.ProductQuantity = model.ProductQuantity;
                product.Color = model.Color;
                product.Config = model.Config;
                product.Description = model.Description;
                product.ProductStatus = model.ProductStatus;
                product.TagID = model.TagID;
                product.SupplierID = model.SupplierID;
                product.UpdatedAt = DateTime.Now;

                result = productServices.SaveProduct(product);
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



        public JsonResult GetSubMenuByMainMenu(int MainMenuID)
        {
            var context = new BrandShopContext();

            context.Configuration.ProxyCreationEnabled = false;

            var SubMenuList = context.SubMenus.Where(x => x.MainMenuID == MainMenuID).ToList();

            return Json(SubMenuList, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult Details(int ID)
        {
            ProductsActionModel model = new ProductsActionModel();

            var product = productServices.GetProductByID(ID);

            model.MainMenus = mainServices.GetAllMainMenus();

            model.SubMenus = subServices.GetSubMenuByMainMenu(model.MainMenuID);

            model.Tags = tagServices.GetAllTags();

            model.Suppliers = supplierServices.GetAllSuppliers();

            return PartialView("_Details", model);

        }

    }
}