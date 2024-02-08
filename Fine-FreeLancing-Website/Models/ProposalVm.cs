using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Fine_FreeLancing_Website.Models
{
    public class ProposalVm
    {
        public string? JobId { get; set; }
        public string? Comment { get; set;}
        
        
    }
}
