using System.ComponentModel.DataAnnotations.Schema;

namespace Fine_FreeLancing_Website.Models
{
    public class ProposalVm
    {
        public string? Comment { get; set; }
        public IFormFile? DocCv { get; set; }
        
    }
}
