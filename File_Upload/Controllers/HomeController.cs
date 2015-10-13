using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using File_Upload.Models;
using System.Web.UI.WebControls;

namespace File_Upload.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FileUpload()
        {
            return View();
        }

        public ActionResult FileUpload(HttpPostedFileBase fl)
        {
          
            if (fl.ContentLength > 0)
            {
                string fileExt = System.IO.Path.GetExtension(Request.Files["fileUpload"].FileName);

                if(fileExt=="xls")
                {
                    string fileLocation =string.Format("{0}/{1}",Server.MapPath("~/ExcelFile"),Request.Files["FileUpload"].FileName);
                    Request.Files["FileUpload"].SaveAs("~/ExcelFile");
                   var excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    //connection String for xls file format.
                    if (fileExt== ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExt == ".xlsx")
                    {

                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }

                }
                else
                { 
                    ViewBag.Message = "sorry, Please select Excel File";
                    ViewBag.Bool = false;
                }
                ViewBag.Message = "Your File Has been uploaded";
                ViewBag.Bool = true;
            }
            else 
            {
                ViewBag.Message = "sorry, File Has not been uploaded";
                ViewBag.Bool = false;
            }
            return View();
        }


    }


}