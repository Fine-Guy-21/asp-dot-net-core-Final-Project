using Microsoft.AspNetCore.Identity;

namespace Fine_FreeLancing_Website.Models
{
    public class User : IdentityUser
    {
        //Id
        //UserName
        //Email
        //PasswordHash
        //PhoneNumber
        public string FullName { get; set; }
        public string? UserProfilePicUrl { get; set; }
        public string? PortfolioUrl { get; set; }
        public bool PremiumUser { get; set; }
        public int UserRating { get; set; }
    }
}
