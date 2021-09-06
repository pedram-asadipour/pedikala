using _01_Framework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Framework;

namespace ServiceHost.Controller
{
    [Authorize]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IFileManager _fileManager;
        private readonly IWebHostEnvironment _webHost;

        public HomeController(IFileManager fileManager, IWebHostEnvironment webHost)
        {
            _fileManager = fileManager;
            _webHost = webHost;
        }

        [HttpPost, Route("UploadImage")]
        [NeedsPermission(AdminPermission.Admin)]
        public IActionResult UploadImage(IFormFile upload)
        {
            if (upload.Length <= 0) return null;

            var file = _fileManager.Uploader(upload, "تصاویر-مقالات");

            var path = $"/Uploads/{file}";

            return new JsonResult(new
            {
                Uploaded = true,
                FileName = file,
                Url = path
            });
        }
    }
}
