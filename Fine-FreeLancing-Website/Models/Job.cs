using System.ComponentModel.DataAnnotations;

namespace Fine_FreeLancing_Website.Models
{
    public class Job
    {
        [Key]
        public string JobId { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string? JobDescription { get; set; }
        [Required]
        public string? JobType { get; set; } // contract , part-time , full-time 
        [Required]
        public double JobPrice { get; set; }
        public DateTime JobPostedtime { get; set; }
        [Required]
        public DateTime Expiredate { get; set; }
        public JobStatus JobStatus { get; set; } 
        List<User>? Proposals { get; set; }
        public string? UserId { get; set; }
    }

    public enum JobType
    {
        contract,
        part_time,
        full_time
    }
    public enum JobStatus
    {
        Hiring,
        Closed,
        Completed
        
    }
}

