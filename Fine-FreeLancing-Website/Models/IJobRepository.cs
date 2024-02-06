using Microsoft.EntityFrameworkCore;

namespace Fine_FreeLancing_Website.Models
{
    public interface IJobRepository
    {
        public Job GetJobById(string id);
        public Job SaveJob(Job job);
        public Job UpdateJob(Job job);
        public void DeleteJob(Job job);
        public List<Job> GetallJobs();
        public List<Job> MyJobs(string JobID, string UserId);
        public List<Job> MyPostedJobs(string JobID, string UserId);     
    }
}

