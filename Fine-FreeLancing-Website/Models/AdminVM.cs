using System.ComponentModel.DataAnnotations;

namespace Fine_FreeLancing_Website.Models
{
    public class AdminVM
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Your Gender is Essential please Select Your Gender")]
        public Genders Gender { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
