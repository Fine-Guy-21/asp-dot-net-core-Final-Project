using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fine_FreeLancing_Website.Models
{
    public class Proposal
    {
        [Key]
        public int ProposalId { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public string? Comment { get; set; }
        public IFormFile? DocCv { get; set; }
        
    }
}
