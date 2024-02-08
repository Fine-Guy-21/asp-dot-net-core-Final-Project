namespace Fine_FreeLancing_Website.Models
{
    public class ProposalJobVm
    {
        public string ProposalId {  get; set; }
        public string Comment { get; set;}
        public Job Job { get; set; }
        public User user { get; set; }
    }
}
