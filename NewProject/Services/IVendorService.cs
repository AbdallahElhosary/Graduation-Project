namespace NewProject.Services
{
    public interface IVendorService
    {
        IEnumerable<SelectListItem> GetVendors();
    }
}
