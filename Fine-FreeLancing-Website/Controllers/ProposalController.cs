using Fine_FreeLancing_Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Fine_FreeLancing_Website.Controllers
{
    public class ProposalController : Controller
    {
        private readonly IJobRepository jobRepository; 
        private readonly UserManager<User> userManager;
        public ProposalController(IJobRepository jobRepository,UserManager<User> userManager)
        {
            
            this.jobRepository = jobRepository;
            this.userManager = userManager;
        }
        
        [Authorize(Roles = "Freelancer,Premium_User,Admin")]
        public IActionResult MyProposals()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            List<Proposal> proposals = jobRepository.GetMyProposals(user.Id);

            List<ProposalJobVm> pjvmlist = new List<ProposalJobVm>();
            
            foreach (var proposal in proposals)
            {
                ProposalJobVm pjvm= new ProposalJobVm()
                {
                  ProposalId = proposal.ProposalId,
                  Job = jobRepository.GetJobById(proposal.JobId),
                  user = user,
                  Comment = proposal.Comment
                };
                pjvmlist.Add(pjvm);
            } 
            return View(pjvmlist);
        }

        [Authorize(Roles= "Freelancer,Premium_User,Admin")]
        [HttpGet]
        public IActionResult CreateProposal(String Id)
        {
            ProposalVm pvm = new ProposalVm();
            pvm.JobId = Id;
            return View(pvm);
        }

        [Authorize(Roles = "Freelancer,Premium_User,Admin")]
        [HttpPost]
        public IActionResult CreateProposal(ProposalVm pvm)
        {
            var curruser = userManager.FindByNameAsync(User.Identity.Name);            
                string CurrUserId = curruser.Result.Id;

                Proposal newproposal = new Proposal()
                {
                    ProposalId = GetRandomID(),
                    JobId = pvm.JobId,
                    UserId = CurrUserId,
                    Comment = pvm.Comment,
                };
            jobRepository.SaveProposal(newproposal);
            return RedirectToAction("MyProposals");
        }

        [Authorize(Roles= "Freelancer,Premium_User,Admin")]
        [HttpGet]
        public IActionResult UpdateProposal(string Id)
        {
            var proposal = jobRepository.GetProposalById(Id);            
            var proposalvm = new ProposalVm()
            {
                JobId = proposal.JobId,
                Comment = proposal.Comment,
            };
            
            return View(proposalvm);
        }

        [Authorize(Roles = "Freelancer,Premium_User,Admin")]
        [HttpPost]
        public IActionResult UpdateProposal(ProposalVm pvm)
        {
            var proposal = jobRepository.GetProposalByJobId(pvm.JobId);
            
            if (ModelState.IsValid)
            {
                proposal.Comment = pvm.Comment;
                jobRepository.UpdateProposal(proposal);
                RedirectToAction("MyProposals");
            }
            
            return RedirectToAction("MyProposals");
        }
        
        [Authorize(Roles= "Freelancer,Employer,Premium_User,Admin")]
        [HttpGet]
        public IActionResult DeleteProposal(string id)
        {
            var proposal = jobRepository.GetProposalById(id);
            jobRepository.DeleteProposal(proposal);

            return RedirectToAction("MyProposals");
        }

        [Authorize(Roles = "Employer,Premium_User,Admin")]
        public IActionResult Hire(string Id)
        {
            
            var job = jobRepository.GetJobById(Id);
            var proposal = jobRepository.GetProposalByJobId(job.JobId);
            if (proposal != null)
            {
                var user = userManager.FindByIdAsync(proposal.UserId).Result;
                
                MyJob myJob = new MyJob()
                {
                    MyJobId = GetRandomID(),
                    JobId = job.JobId,
                    UserId = proposal.UserId     
                };
                jobRepository.SaveMyjob(myJob);

                return RedirectToAction("PostedJobs","Job");
            }
            return RedirectToAction("PostedJobs","Job");
        }


        
            public string GetRandomID()
        {
            string id = Guid.NewGuid().ToString("N");
            return id;
        }

    }

}
