namespace NewProject.Services
{
    public interface INeededItemService
    {
        Task AddNeededItem(NeededItemViewModel Model);
        IEnumerable<NeededItem> GetAllLast();
        NeededItem? Edit(SpecificationNeededItemViewModel Model);
        NeededItem? GetById(int id);
        IEnumerable<SpecificationNeededItemViewModel> GetAllItem();

    }
}
