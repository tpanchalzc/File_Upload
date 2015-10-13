using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace File_Upload.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Upload(HttpPostedFileBase myFile)
        {
            if (myFile != null && myFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(myFile.FileName);
                string path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                myFile.SaveAs(path);
                string connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES\";", path);

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                }
                return "success";
            }
            return "failed";
        }
    }
}