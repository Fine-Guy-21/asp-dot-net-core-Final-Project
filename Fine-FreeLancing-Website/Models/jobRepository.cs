namespace Fine_FreeLancing_Website.Models
{
    public class JobRepository : IJobRepository
    {
        private readonly MyDbContext myDbContext;
        public JobRepository (MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public Job GetJobById (string id)
        {
            Job? job = myDbContext.Jobs.Where(j => j.JobId == id).FirstOrDefault();  
            return job;
        }

        public Job SaveJob(Job job) 
        {
            myDbContext.Jobs.Add(job);
            myDbContext.SaveChanges();
            return job;
        }

        public Job UpdateJob(Job job)
        {
            myDbContext.Jobs.Update(job);
            myDbContext.SaveChanges();
            return job;
        }

        public void DeleteJob(Job job)
        {
            myDbContext.Jobs.Remove(job);
            myDbContext.SaveChanges();
        }

        public List<Job> GetallJobs()
        {

            return myDbContext.Jobs.ToList();
        }

        public List<Job> MyJobs(string JobID, string UserId)
        {
            
            return myDbContext.Jobs.ToList();
        }

        public List<Job> MyPostedJobs(string JobID, string UserId)
        {
            return myDbContext.Jobs.ToList();
        }

    }
}
