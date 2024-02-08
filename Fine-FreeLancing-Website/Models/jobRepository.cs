namespace Fine_FreeLancing_Website.Models
{
    public class JobRepository : IJobRepository
    {
        private readonly MyDbContext myDbContext;
        public JobRepository (MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public Job GetJobById(string id)
        {
            Job? job = myDbContext.Jobs.Where(j => j.JobId == id).FirstOrDefault();  
            return job;
        }

        public Proposal GetProposalById(string id)
        {
            Proposal? proposal = myDbContext.Proposals.Where(j => j.ProposalId == id).FirstOrDefault();
            return proposal;
        }
        public Proposal GetProposalByJobId(string jid)
        {

            Proposal? proposal = myDbContext.Proposals.Where(j => j.JobId == jid).FirstOrDefault();
            return proposal;
        }
        public Proposal GetProposalByJobandUserId(string jid,string uid)
        {
            
            Proposal? proposal = myDbContext.Proposals.Where(j => j.JobId == jid && j.UserId == uid).FirstOrDefault();
            return proposal;
        }

        public Job GetMyJobById(string jid,string uid )
        {
            Job? job = myDbContext.Jobs.Where(j =>j.JobId==jid && j.UserId == uid).FirstOrDefault();
            return job;
        }
        public List<Job> GetMyPostedJobs(string uid)
        {
            List<Job>? jobs = myDbContext.Jobs.Where(j => j.UserId == uid).ToList();
            return jobs;
        }
        public List<Proposal> GetMyProposals(string uid)
        {
            List<Proposal>? proposals = myDbContext.Proposals.Where(p=>p.UserId == uid).ToList();
            return proposals;
        }

        public List<Proposal> GetProposalsByJobId(string id)
        {
            
            List<Proposal>? proposals = myDbContext.Proposals.Where(p => p.JobId == id).ToList();
            return proposals;

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
        public MyJob SaveMyjob(MyJob myjob)
        {
            myDbContext.MyJobs.Add(myjob);
            myDbContext.SaveChanges();
            return myjob;
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
        public void DeleteMyJob(MyJob myjob)
        {
            myDbContext.MyJobs.Remove(myjob);
            myDbContext.SaveChanges();
        }
        public List<MyJob> MyJobs(string UserId)
        {            
            return myDbContext.MyJobs.Where(u=>u.UserId==UserId).ToList();
        }

        

    }
}
