using Fine_FreeLancing_Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Fine_FreeLancing_Website.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRepository jobRepository;
        private readonly UserManager<User> userManager;
        public JobController(IJobRepository _jobRepository,UserManager<User> _userManager )
        {
            jobRepository = _jobRepository;
            userManager = _userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()=> View(jobRepository.GetallJobs());

        [Authorize]
        [Authorize(Roles = "Employer,Premium_User")]  
        [HttpGet]
        public IActionResult PostJob()=> View();
        [Authorize]
        [Authorize(Roles= "Employer,Premium_User")]        
        [HttpPost]
        public IActionResult PostJob(JobVM jobvm)
        { 
            jobvm.JobId = Guid.NewGuid().ToString(); 
            if(ModelState.IsValid)
            {
                var curruser = userManager.FindByNameAsync(User.Identity.Name).Result;                
                Job newjob = new Job
                {
                    JobId = jobvm.JobId,
                    JobTitle = jobvm.JobTitle,
                    JobDescription = jobvm.JobDescription,
                    JobType = jobvm.JobType,
                    JobPrice = jobvm.JobPrice,
                    JobPostedtime = DateTime.Now,
                    Expiredate = jobvm.Expiredate,
                    JobStatus = JobStatus.Hiring,
                    UserId = curruser.Id
                };
                jobRepository.SaveJob(newjob);

                return RedirectToAction("Index" ,"Home");
            }
            return View();
        }

        [Authorize(Roles = "Employer,Premium_User,Admin")]
        [HttpGet]
        public IActionResult EditJob(String Id)
        {
            Job job = jobRepository.GetJobById(Id);
            JobVM jobvm= new JobVM();
            
            if (job != null) 
            {
                jobvm.JobId = job.JobId;
                jobvm.JobTitle = job.JobTitle;
                jobvm.JobDescription = job.JobDescription;
                jobvm.JobType = job.JobType;    
                jobvm.JobPrice = job.JobPrice;
                jobvm.Expiredate = job.Expiredate;
                jobvm.JobStatus = job.JobStatus;
            } 
             
            return View(jobvm);
        }


        [Authorize(Roles = "Employer,Premium_User,Admin")]
        [HttpPost] 
        public IActionResult EditJob(JobVM jobvm)
        {
            if (jobvm != null)
            {
                Job job = jobRepository.GetJobById(jobvm.JobId);
                
                job.JobTitle = jobvm.JobTitle;
                job.JobDescription = jobvm.JobDescription;
                job.JobType = jobvm.JobType;
                job.JobPrice = jobvm.JobPrice;
                job.Expiredate = jobvm.Expiredate;
                job.JobStatus = jobvm.JobStatus;

                jobRepository.UpdateJob(job);
            }
            return RedirectToAction("PostedJobs","Job");
        }

        [Authorize(Roles = "Employer,Premium_User,Admin")]
        [HttpGet]
        public IActionResult DeleteJob(String Id)
        {
            Job job = jobRepository.GetJobById(Id);
            if (job != null)
            {
                jobRepository.DeleteJob(job);   
            }
            return RedirectToAction("Index","Job");
        }

        [AllowAnonymous]
        public IActionResult JobDetail(String Id)
        {
            Job job = jobRepository.GetJobById(Id);
            if (job != null)
            {
                return View(job);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Freelancer,Premium_User,Admin")]
        public IActionResult MyJobs()
        {
            
            return View();
        }
        [Authorize(Roles = "Employer,Premium_User,Admin")]
        public IActionResult PostedJobs()
        {

            return View(jobRepository.GetallJobs());
        }

        public string GetRandomID()
        {
            string id = Guid.NewGuid().ToString("N");
            return id;
        }
    }
}
