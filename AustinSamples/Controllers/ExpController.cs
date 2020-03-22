using AustinSamples.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AustinSamples.Controllers
{
    public class ExpController : Controller
    {
        // GET: Exp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase postedFile)
        {
            string path = Server.MapPath("~/UploadedFiles/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (postedFile != null)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                postedFile.SaveAs(path + fileName);
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            }

            return View();
        }

        public ActionResult DynamicGrid()
        {
            
            
            return View();
        }

        [HttpGet]
        public JsonResult AjaxMethod()
        {
            if (Session["MyData"] == null)
            {
                List<IncidentMD> entities = new List<IncidentMD>()
               {
                new IncidentMD(){ Id=1, Name="Bill", Country="India",Gender="Male",IsMarried=true},
                new IncidentMD(){ Id=2, Name="Steve",Country="India",Gender="Male",IsMarried=true},
                new IncidentMD(){ Id=3, Name="Ram",Country="India",Gender="Male",IsMarried=true },
                new IncidentMD(){ Id=4, Name="Moin",Country="India",Gender="Male",IsMarried=true}
                };
                Session["MyData"] = entities;
                return Json(entities, JsonRequestBehavior.AllowGet);
            }
            else
            {

                List<IncidentMD> entities= Session["MyData"] as List<IncidentMD>;
                return Json(entities, JsonRequestBehavior.AllowGet);

            }

        }

        [HttpGet]
        public JsonResult GetCountries()
        {
            List<String> countries = new List<String>();
            countries.Add("India");
            countries.Add("USA");
            countries.Add("Africa");
            countries.Add("Bali");
            countries.Add("GreenLand");
            
            return Json(countries, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InsertCustomers(List<IncidentMD> customers)
        {

                Session["MyData"] = customers;
                return Json(new { Success = true});

        }

    }
}