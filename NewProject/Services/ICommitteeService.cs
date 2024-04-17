namespace NewProject.Services
{
    public interface ICommitteeService
    {
        Task AddCommitteeMembers(CommitteeViewModel model);
        SpecifictionCommittee GetBySpecifictionCommitteeID();
        TechnicalCommittee GetByTechnicalCommitteeId();
        SelectionCommittee GetBySelectionCommitteeId();

       
    }
}
