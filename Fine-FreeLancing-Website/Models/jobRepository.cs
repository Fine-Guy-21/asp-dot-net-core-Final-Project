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

        public List<Job> GetMyJobById(string jid, string uid)
        {
            List<Job>? jobs = myDbContext.Jobs.Where(j => j.JobId == jid && j.UserId == uid).ToList();
            return jobs;
        }

        public Job SaveJob(Job job) 
        {
            myDbContext.Jobs.Add(job);
            myDbContext.SaveChanges();
            return job;
        }

        public Proposal SaveProposal(Proposal proposal)
        {
            myDbContext.Proposals.Add(proposal);
            myDbContext.SaveChanges();
            return proposal;
        }
        

        public Job UpdateJob(Job job)
        {
            myDbContext.Jobs.Update(job);
            myDbContext.SaveChanges();
            return job;
        }

        public Proposal UpdateProposal(Proposal proposal)
        {
            myDbContext.Proposals.Update(proposal);
            myDbContext.SaveChanges();
            return proposal;
        }

        public void DeleteJob(Job job)
        {
            myDbContext.Jobs.Remove(job);
            myDbContext.SaveChanges();
        }
        public void DeleteProposal(Proposal proposal)
        {
            
            myDbContext.Proposals.Remove(proposal);
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
