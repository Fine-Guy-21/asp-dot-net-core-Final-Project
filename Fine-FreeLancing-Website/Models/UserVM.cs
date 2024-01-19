using System.ComponentModel.DataAnnotations;

namespace Fine_FreeLancing_Website.Models
{
    public class UserVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Portfolio Link")]
        public string? PortfolioUrl { get; set; }
        
    }
}

/*
 var user = _dbContext.Users.FirstOrDefault(u =>
            u.Email == emailOrUsername || u.Username == emailOrUsername);
 */