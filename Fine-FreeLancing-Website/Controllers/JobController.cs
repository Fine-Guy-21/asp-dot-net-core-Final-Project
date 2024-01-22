using Fine_FreeLancing_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Fine_FreeLancing_Website.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PostJob()=> View();

        [HttpPost]
        public IActionResult PosttJob(JobVM jobvm)
        { 

            return View();
        }
        public string GetRandomID()
        {
            string id = Guid.NewGuid().ToString("N");
            return id;
        }
    }
}
