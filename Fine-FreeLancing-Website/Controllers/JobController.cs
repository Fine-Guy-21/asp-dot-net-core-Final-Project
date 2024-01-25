using Fine_FreeLancing_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public IActionResult PostJob(JobVM jobvm)
        { 
            jobvm.JobId = Guid.NewGuid().ToString(); 
            if(ModelState.IsValid)
            {
                Job newjob = new Job
                {
                    JobId = jobvm.JobId,
                    JobTitle = jobvm.JobTitle,
                    JobDescription = jobvm.JobDescription,
                    JobType = jobvm.JobType,
                    JobPrice = jobvm.JobPrice,
                    Expiredate = jobvm.Expiredate,
                    JobStatus = jobvm.JobStatus,
                };

                return RedirectToAction("Index" ,"Home");
            }
            return View();
        }
        public string GetRandomID()
        {
            string id = Guid.NewGuid().ToString("N");
            return id;
        }
    }
}
