using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fine_FreeLancing_Website.Models
{
    public class MyJob
    {
        [Key]
        public string MyJobId { get; set; } 
        public string UserId { get; set; }
        public string JobId { get; set; }


    }
}
