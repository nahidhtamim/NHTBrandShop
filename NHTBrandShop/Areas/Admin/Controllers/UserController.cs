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
    public class UserController : Controller
    {
        
        UserServices services = new UserServices();
        RoleServices roleServices = new RoleServices();

        // GET: Admin/User
        public ActionResult Index()
        {
            UserListingModel model = new UserListingModel();

            model.Users = services.GetAllUsers();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddAndEdit(int? ID)
        {
            UserActionModel model = new UserActionModel();

            if (ID.HasValue)
            {
                var User = services.GetUserByID(ID.Value);

                model.UserID = User.UserID;
                model.RoleID = User.RoleID;
                model.UserName = User.UserName;
                model.Password = User.Password;
                model.UserName = User.UserName;
                model.EmailAddress = User.EmailAddress;
                model.MobileNo = User.MobileNo;
                model.Address = User.Address;
                model.BillingAddress = User.BillingAddress;
            }
            model.Roles = roleServices.GetAllRoles();
            return PartialView("_AddAndEdit", model);
        }

        [HttpPost]
        public JsonResult AddAndEdit(UserActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.UserID > 0)
            {
                var user = services.GetUserByID(model.UserID);

                user.RoleID = model.RoleID;
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.EmailAddress = model.EmailAddress;
                user.MobileNo = model.MobileNo;
                user.Address = model.Address;
                user.BillingAddress = model.BillingAddress;
                user.UpdatedAt = DateTime.Now;

                result = services.UpdateUser(user);
            }
            else
            {
                User user = new User();

                user.RoleID = model.RoleID;
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.EmailAddress = model.EmailAddress;
                user.MobileNo = model.MobileNo;
                user.Address = model.Address;
                user.BillingAddress = model.BillingAddress;
                user.UpdatedAt = DateTime.Now;

                result = services.SaveUser(user);
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
            UserActionModel model = new UserActionModel();

            var user = services.GetUserByID(ID);

            model.UserID = user.UserID;

            return PartialView("_Delete", model);

        }

        [HttpPost]
        public JsonResult Delete(UserActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var user = services.GetUserByID(model.UserID);

            result = services.DeleteUser(user);

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