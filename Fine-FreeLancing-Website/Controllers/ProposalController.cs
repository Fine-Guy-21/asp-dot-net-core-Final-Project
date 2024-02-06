using Fine_FreeLancing_Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fine_FreeLancing_Website.Controllers
{
    public class ProposalController : Controller
    {
        private readonly MyDbContext myDbContext;
        public ProposalController(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(ProposalVm pvm)
        {
            return View();
        }
            
    }

}
