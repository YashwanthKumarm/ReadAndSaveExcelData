using Newtonsoft.Json;
using ReadAndSaveExcelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadAndSaveExcelData.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ExcelSaveData(List<string> preferredData)
        {
            string requiredString = string.Join("", preferredData);
            ExcelViewModel[] modelCollection=JsonConvert.DeserializeObject<ExcelViewModel[]>(requiredString);
            FirstDatabaseEntities db = new FirstDatabaseEntities();
            foreach (var item in modelCollection)
            {
                TBL_Excel_File model = new TBL_Excel_File();
                model.Category = item.Category;
                model.Functionality = item.Functionality;
                model.Description = item.Description;
                model.New = item.New;
                model.HelpTopic = item.HelpTopic;
                db.TBL_Excel_File.Add(model);
                db.SaveChanges(); 
            }
            bool status = false;
            return new JsonResult { Data = new { status = status } };
        }
    }
}