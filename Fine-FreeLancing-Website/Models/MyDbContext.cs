using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Fine_FreeLancing_Website.Models
{
    public class MyDbContext : IdentityDbContext<User>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        
        DbSet<Job> Jobs { get; set; }
        //DbSet<Proposal> Proposals { get; set; }
    }
}
