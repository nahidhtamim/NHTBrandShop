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
    public class SubMenuController : Controller
    {
        MainMenuServices mainServices = new MainMenuServices();

        SubMenuServices subServices = new SubMenuServices();

        SharedServices sharedServices = new SharedServices();

        // GET: Admin/SubMenu
        public ActionResult Index()
        {
            SubMenuListingModel model = new SubMenuListingModel();

            model.MainMenus = mainServices.GetAllMainMenus();

            model.subMenus = subServices.GetAllSubMenus();

            return View(model);
        }
        //public ActionResult Index(string SearchTerm)
        //{
        //    SubMenuListingModel model = new SubMenuListingModel();

        //    model.SearchTerm = SearchTerm;

        //    model.MainMenus = mainServices.GetAllMainMenus();

        //    model.subMenus = subServices.SearchSubMenus(SearchTerm);

        //    return View(model);
        //}

        [HttpGet]
        public ActionResult AddAndEdit(int? ID)
        {
            SubMenuActionModel model = new SubMenuActionModel();

            if (ID.HasValue)
            {
                var subMenu = subServices.GetSubMenuByID(ID.Value);

                model.SubMenuID = subMenu.SubMenuID;
                model.MainMenuID = subMenu.MainMenuID;
                model.SubMenuName = subMenu.SubMenuName;
                model.Description = subMenu.Description;

                model.SubMenuPictures = subServices.GetPictureBySubMneID(subMenu.SubMenuID);
            }
            model.MainMenus = mainServices.GetAllMainMenus();

            return PartialView("_AddAndEdit", model);

        }

        [HttpPost]
        public JsonResult AddAndEdit(SubMenuActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            List<int> pictureIDs = !string.IsNullOrEmpty(model.PictureIDs) ? model.PictureIDs.Split(',').Select(x => int.Parse(x)).ToList() : new List<int>();

            var pictures = sharedServices.GetPictureByIDs(pictureIDs);

            if (ModelState.IsValid)
            {
                if (model.SubMenuID > 0)
                {
                    var subMenu = subServices.GetSubMenuByID(model.SubMenuID);

                    subMenu.MainMenuID = model.MainMenuID;
                    subMenu.SubMenuName = model.SubMenuName;
                    subMenu.Description = model.Description;
                    subMenu.UpdatedAt = DateTime.Now;

                    subMenu.SubMenuPictures.Clear();
                    subMenu.SubMenuPictures.AddRange(pictures.Select(x => new SubMenuPicture() { SubMenuID = subMenu.SubMenuID, PictureID = x.PictureID }));

                    result = subServices.UpdateSubMenu(subMenu);
                }
                else
                {
                    SubMenu subMenu = new SubMenu();

                    subMenu.MainMenuID = model.MainMenuID;
                    subMenu.SubMenuName = model.SubMenuName;
                    subMenu.Description = model.Description;
                    subMenu.UpdatedAt = DateTime.Now;

                    subMenu.SubMenuPictures = new List<SubMenuPicture>();
                    subMenu.SubMenuPictures.AddRange(pictures.Select(x => new SubMenuPicture() { PictureID = x.PictureID }));

                    result = subServices.SaveSubMenu(subMenu);
                }
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
            SubMenuActionModel model = new SubMenuActionModel();

            var subMenu = subServices.GetSubMenuByID(ID);

            model.SubMenuID = subMenu.SubMenuID;

            return PartialView("_Delete", model);
        }

        public JsonResult Delete(SubMenuActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var subMenu = subServices.GetSubMenuByID(model.SubMenuID);

            result = subServices.DeleteSubMenu(subMenu);

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