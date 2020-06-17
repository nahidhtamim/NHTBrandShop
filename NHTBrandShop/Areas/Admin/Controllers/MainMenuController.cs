using NHTBrandShop.Areas.Admin.Models;
using NHTBrandShop.Entities;
using NHTBrandShop.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHTBrandShop.Areas.Admin.Controllers
{
    public class MainMenuController : Controller
    {
        MainMenuServices services = new MainMenuServices();
        // GET: Admin/MainMenu
        //public ActionResult Index(string SearchTerm)
        //{
        //    MainMenuListingModel model = new MainMenuListingModel();

        //    model.SearchTerm = SearchTerm;

        //    model.MainMenus = services.SearchMainMenus(SearchTerm);

        //    return View(model);
        //}
        public ActionResult Index()
        {
            MainMenuListingModel model = new MainMenuListingModel();

            model.MainMenus = services.GetAllMainMenus();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddAndEdit(int? ID)
        {
            MainMenuActionModel model = new MainMenuActionModel();

            if (ID.HasValue)
            {
                var mainMenu = services.GetMainMenuByID(ID.Value);

                model.MainMenuID = mainMenu.MainMenuID;

                model.MainMenuName = mainMenu.MainMenuName;

                model.Description = mainMenu.Description;

            }

            return PartialView("_AddAndEdit", model);

        }

        [HttpPost]
        public JsonResult AddAndEdit(MainMenuActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.MainMenuID > 0)
            {
                var mainMenu = services.GetMainMenuByID(model.MainMenuID);

                mainMenu.MainMenuName = model.MainMenuName;

                mainMenu.Description = model.Description;

                mainMenu.UpdatedAt = DateTime.Now;

                result = services.UpdateMenu(mainMenu);
            }
            else
            {
                MainMenu mainMenu = new MainMenu();

                mainMenu.MainMenuName = model.MainMenuName;

                mainMenu.Description = model.Description;

                mainMenu.UpdatedAt = DateTime.Now;

                result = services.SaveMenu(mainMenu);
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
            MainMenuActionModel model = new MainMenuActionModel();

            var mainMenu = services.GetMainMenuByID(ID);

            model.MainMenuID = mainMenu.MainMenuID;

            return PartialView("_Delete", model);

        }

        [HttpPost]
        public JsonResult Delete(MainMenuActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var mainMenu = services.GetMainMenuByID(model.MainMenuID);

            result = services.DeleteMenu(mainMenu);

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