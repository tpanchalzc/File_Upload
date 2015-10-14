using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
        public ActionResult Upload(HttpPostedFileBase myFile)
        {
            Application xlApp = null;
            Workbook book = null;
            try
            {
                //myFile = Request.Files[0];
                if (myFile != null && myFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(myFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                    myFile.SaveAs(path);

                    xlApp = new Application();
                    book = xlApp.Workbooks.Open(path);

                    string res = "Total worksheets are:" + book.Worksheets.Count;

                    List<List<string>> data = new List<List<string>>();

                    Worksheet ws = book.Worksheets[1];
                    for (int i = 5; i < 50; i++)
                    {
                        List<string> row = new List<string>();
                        for (int j = 5; j < 50; j++)
                        {
                            string tmp = ""+(ws.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value;
                            row.Add(tmp);
                        }
                        data.Add(row);
                    }
                    Marshal.ReleaseComObject(ws);
                    book.Close();
                    return PartialView("SheetDataView", data);
                    //return Content(res);
                }
                else return Content("failed");
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
            finally
            {
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(xlApp);
                book = null;
                xlApp = null;
            }
        }
    }
}