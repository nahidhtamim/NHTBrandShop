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
    public class RoleController : Controller
    {
        
        RoleServices services = new RoleServices();

        // GET: Admin/Role
        public ActionResult Index()
        {
            RoleListingModel model = new RoleListingModel();

            model.Roles = services.GetAllRoles();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddAndEdit(int? ID)
        {
            RoleActionModel model = new RoleActionModel();

            if (ID.HasValue)
            {
                var role = services.GetRoleByID(ID.Value);

                model.RoleID = role.RoleID;

                model.RoleName = role.RoleName;

            }

            return PartialView("_AddAndEdit", model);

        }

        [HttpPost]
        public JsonResult AddAndEdit(RoleActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.RoleID > 0)
            {
                var role = services.GetRoleByID(model.RoleID);

                role.RoleName = model.RoleName;

                role.UpdatedAt = DateTime.Now;

                result = services.UpdateRole(role);
            }
            else
            {
                Role role = new Role();

                role.RoleName = model.RoleName;

                role.UpdatedAt = DateTime.Now;

                result = services.SaveRole(role);
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
            RoleActionModel model = new RoleActionModel();

            var role = services.GetRoleByID(ID);

            model.RoleID = role.RoleID;

            return PartialView("_Delete", model);

        }

        [HttpPost]
        public JsonResult Delete(RoleActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var role = services.GetRoleByID(model.RoleID);

            result = services.DeleteRole(role);

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