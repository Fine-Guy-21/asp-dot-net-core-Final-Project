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
            return RedirectToAction("","Job");
        }

        [Authorize(Roles= "Freelancer,Premium_User,Admin")]
        [HttpGet]
        public IActionResult UpdateProposal() => View();

        [Authorize(Roles = "Freelancer,Premium_User,Admin")]
        [HttpPost]
        public IActionResult UpdateProposal(ProposalVm pvm)
        {
            return View();
        }
        
        [Authorize(Roles= "Freelancer,Premium_User,Admin")]
        [HttpGet]
        public IActionResult DeleteProposal()
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
