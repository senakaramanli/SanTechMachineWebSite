using Microsoft.AspNetCore.Mvc;
using SanTechMakina.Models;
using System.Diagnostics;

namespace SanTechMakina.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<GalleryImage> images = new List<GalleryImage>();

            DirectoryInfo d = new DirectoryInfo("././wwwroot/Img");

            FileInfo[] Files = d.GetFiles();
           
            foreach (FileInfo file in Files)
            {
                GalleryImage image = new GalleryImage()
                {
                    Id = new Guid(),
                    Name = file.Name,
                    Url = file.FullName
                };

                images.Add(image);
            }

            return View(images);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Gallery()
        {
            List<GalleryImage> images = new List<GalleryImage>();

            DirectoryInfo d = new DirectoryInfo("././wwwroot/Img");

            FileInfo[] Files = d.GetFiles(); 
            string str = "";

            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
            }

            return View(images); 
        }


    }
}