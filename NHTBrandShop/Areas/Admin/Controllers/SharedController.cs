using NHTBrandShop.Entities;
using NHTBrandShop.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHTBrandShop.Areas.Admin.Controllers
{
    public class SharedController : Controller
    {
        //SharedServices service = new SharedServices();


        // GET: Admin/Shared
        //public ActionResult Index()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public JsonResult UploadPictures()
        //{
        //    JsonResult result = new JsonResult();

        //    List<object> pictureJSON = new List<object>();

        //    var pictures = Request.Files;

        //    for (int i = 0; i < pictures.Count; i++)
        //    {
        //        var picture = pictures[i];

        //        var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);

        //        var path = Server.MapPath("~/images/") + fileName;

        //        picture.SaveAs(path);

        //        var dbPicture = new Picture();

        //        dbPicture.Url = fileName;

        //        int pictureID = service.SavePicture(dbPicture);

        //        pictureJSON.Add(new { ID = pictureID, pictureURL = fileName });
        //    }

        //    result.Data = pictureJSON;

        //    return result;
        //}

        [HttpPost]
        public JsonResult UploadPictures()
        {
            JsonResult result = new JsonResult();

            var sharedServices = new SharedServices();

            var picsList = new List<Picture>();

            var files = Request.Files;

            for (int i = 0; i < files.Count; i++)
            {
                var picture = files[i];

                var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);

                var filePath = Server.MapPath("~/images/") + fileName;

                picture.SaveAs(filePath);

                var dbPicture = new Picture();

                dbPicture.Url = fileName;

                if (sharedServices.SavePicture(dbPicture))
                {
                    picsList.Add(dbPicture);
                }

            }
            result.Data = picsList;

            return result;
        }
    }
}