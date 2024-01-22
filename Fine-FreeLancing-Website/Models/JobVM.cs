using System.ComponentModel.DataAnnotations;

namespace Fine_FreeLancing_Website.Models
{
    public class JobVM
    {
        public string JobId { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? JobType { get; set; } // contract , part-time , full-time 
        public double JobPrice{ get; set; }
        public DateTime Expiredate { get; set; }
        public bool JobStatus { get; set; }
    }
}
