using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Fine_FreeLancing_Website.Models
{
    public class MyDbContext : IdentityDbContext<User>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<MyJob> MyJobs { get; set; }
        public DbSet<PostedJob> PostedJobs { get; set; }

    }
}
