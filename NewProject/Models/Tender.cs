namespace NewProject.Models
{
    public class Tender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly DateOnly { get; set; }
        public ICollection<NeededItem>? RequiredItems { get; set; }
        public SelectionCommittee? selectionCommittee { get; set; }
        public TechnicalCommittee? TechnicalCommittee { get; set; }
        public SpecifictionCommittee? SpecifictionCommittee { get; set; }

    }
}
