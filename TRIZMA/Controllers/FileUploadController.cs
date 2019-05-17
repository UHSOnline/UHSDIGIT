using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using TRIZMA.Models;
using System.Web.Mvc;

namespace TRIZMA.Controllers
{
    public class FileUploadController : ApiController
    {
        // GET: UploadFile
        public string[] UploadFiles()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            string[] path = new string[files.Count];
            for (var i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string roothPath = @"~\upload\uplCadence\" + file.FileName;
                path[i] = roothPath.Substring(1);
                file.SaveAs(HttpContext.Current.Server.MapPath(roothPath));
            }
            return path;
        }
    }
}