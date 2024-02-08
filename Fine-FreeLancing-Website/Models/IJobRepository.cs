using Microsoft.EntityFrameworkCore;

namespace Fine_FreeLancing_Website.Models
{
    public interface IJobRepository
    {
        public Job GetJobById(string id);
        public Proposal GetProposalById(string id);
        public Proposal GetProposalByJobId(string id);
        public Job GetMyJobById(string jid, string uid); 
        public Job SaveJob(Job job);
        public Proposal SaveProposal(Proposal proposal);
        public MyJob SaveMyjob(MyJob myjob); 
        public Job UpdateJob(Job job);
        public Proposal UpdateProposal(Proposal proposal);
        public void DeleteJob(Job job);
        public void DeleteProposal(Proposal proposal);
        public List<Job> GetallJobs();
        public List<MyJob> MyJobs(string UserId);
        public List<Job> GetMyPostedJobs(string uid);
        public List<Proposal> GetMyProposals(string uid);
    
    }
}

