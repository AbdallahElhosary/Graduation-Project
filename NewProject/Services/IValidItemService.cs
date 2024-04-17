namespace NewProject.Services
{
    public interface IValidItemService
    {
        ValidItem? GetById(int id);
        Task ValidItem(int id);
        IEnumerable<ValidItem> ValidItems();
        IEnumerable<SelectListItem> GetValidItems();
        ValidItem? GetValiditemByneededitemid(int id);//okk
    }
}
