using Fine_FreeLancing_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;

namespace Fine_FreeLancing_Website.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRepository jobRepository;
        public JobController(IJobRepository _jobRepository)
        {
            jobRepository = _jobRepository;
        }

        public IActionResult Index()=> View(jobRepository.GetallJobs());
        
        [HttpGet]
        public IActionResult PostJob()=> View();

        [HttpPost]
        public IActionResult PostJob(JobVM jobvm)
        { 
            jobvm.JobId = Guid.NewGuid().ToString(); 
            if(ModelState.IsValid)
            {
                //JobStatus jobStatus = JobStatus.Hiring;
                Job newjob = new Job
                {
                    JobId = jobvm.JobId,
                    JobTitle = jobvm.JobTitle,
                    JobDescription = jobvm.JobDescription,
                    JobType = jobvm.JobType,
                    JobPrice = jobvm.JobPrice,
                    Expiredate = jobvm.Expiredate,
                    JobStatus = JobStatus.Hiring
                };
                jobRepository.SaveJob(newjob);

                return RedirectToAction("Index" ,"Home");
            }
            return View();
        }

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
            }
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteJob(String Id)
        {
            Job job = jobRepository.GetJobById(Id);
            if (job != null)
            {
                jobRepository.DeleteJob(job);   
            }
            return RedirectToAction("Index","Job");
        }

        public IActionResult MyJobs()
        {
            return View();
        }
        public IActionResult PostedJobs()
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
