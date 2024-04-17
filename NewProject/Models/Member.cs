namespace NewProject.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Password { get; set; }
        public ICollection<SelectionCommitteeMember> selectionCommitteeMembers { get; set; }
        public ICollection<SpecifictionCommitteeMember> specifictionCommitteeMembers { get;set; }
        public ICollection<TechnicalCommitteeMember> technicalCommitteeMembers { get; set; }
    }
}
