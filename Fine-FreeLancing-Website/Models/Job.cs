using System.ComponentModel.DataAnnotations;

namespace Fine_FreeLancing_Website.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? JobType { get; set; } // contract , part-time , full-time 
        public string? Experience { get; set; }
        public DateTime Expiredate { get; set; }
        public bool JobStatus { get; set; }
        List<User>? Proposals { get; set; }
    }
}

