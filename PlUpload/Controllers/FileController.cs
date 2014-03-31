using System.IO;
using System.Web.Mvc;

namespace PlUpload.Controllers
{
    public class FileController : Controller
    {

        public ActionResult Upload()
        {
            return View();
        }

        /// <summary>  
        /// Handles chuncked file uploads like the ones from plupload.  
        /// </summary>  
        /// <param name="chunk"></param>  
        /// <param name="name"></param>  
        /// <returns></returns>  
        [HttpPost]
        public ActionResult Upload(int? chunk, int? chunks, string name)
        {
            var fileUpload = Request.Files[0];
            var uploadPath = Server.MapPath("~/App_Data");
            chunk = chunk ?? 0;
            chunks = chunks ?? 1;

            //write chunk to disk.  
            string uploadedFilePath = Path.Combine(uploadPath, name);
            using (var fs = new FileStream(uploadedFilePath, chunk == 0 ? FileMode.Create : FileMode.Append))
            {
                var buffer = new byte[fileUpload.InputStream.Length];
                fileUpload.InputStream.Read(buffer, 0, buffer.Length);
                fs.Write(buffer, 0, buffer.Length);
            }

            return Content("Success", "text/plain");
        }  
	}
}