using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FileUploadDemo.Models;
using Microsoft.AspNetCore.Http;
using FileUploadDemo.Filters;

namespace FileUploadDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(List<IFormFile> files)
        {
            // Extract file name from whatever was posted by browser
            foreach(var file in files)
            {
                var fileName = System.IO.Path.GetFileName(file.FileName);

                // If file with same name exists delete it
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }

                using (var localFile = System.IO.File.OpenWrite(fileName))
                {
                    using (var uploadedFIle = file.OpenReadStream())
                    {
                        uploadedFIle.CopyTo(localFile);
                    }
                }
            }            

            ViewBag.message = "File Uploaded.";

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
