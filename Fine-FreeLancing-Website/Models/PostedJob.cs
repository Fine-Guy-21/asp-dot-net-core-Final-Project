using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fine_FreeLancing_Website.Models
{
    public class PostedJob
    {
        [Key]
        public string PostedJobId { get; set; }
        public string UserId { get; set; }
        public string JobId { get; set; }
        
    }
}
