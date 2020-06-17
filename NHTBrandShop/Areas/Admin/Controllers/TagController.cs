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
    public class TagController : Controller
    {
        TagServices services = new TagServices();
        // GET: Admin/Tag
        public ActionResult Index()
        {
            TagListingModel model = new TagListingModel();

            model.Tags = services.GetAllTags();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddAndEdit(int? ID)
        {
            TagActionModel model = new TagActionModel();

            if (ID.HasValue)
            {
                var suppler = services.GetTagByID(ID.Value);

                model.TagID = suppler.TagID;

                model.TagTitle = suppler.TagTitle;

            }
            return PartialView("_AddAndEdit", model);
        }

        [HttpPost]
        public JsonResult AddAndEdit(TagActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.TagID > 0)
            {
                var tag = services.GetTagByID(model.TagID);

                tag.TagTitle = model.TagTitle;

                tag.UpdatedAt = DateTime.Now;

                result = services.UpdateTag(tag);
            }
            else
            {
                Tag tag = new Tag();

                tag.TagTitle = model.TagTitle;

                tag.UpdatedAt = DateTime.Now;

                result = services.SaveTag(tag);
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
            TagActionModel model = new TagActionModel();

            var tag = services.GetTagByID(ID);

            model.TagID = tag.TagID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(TagActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var tag = services.GetTagByID(model.TagID);

            result = services.DeleteTag(tag);

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