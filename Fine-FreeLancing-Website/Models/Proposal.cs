using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fine_FreeLancing_Website.Models
{
    public class Proposal
    {
        [Key]
        public string ProposalId { get; set; }
        public string JobId { get; set; }
        public string UserId { get; set; }  
        public string? Comment { get; set; }
        [NotMapped]
        public IFormFile? DocCv { get; set; }
        
    }
}
