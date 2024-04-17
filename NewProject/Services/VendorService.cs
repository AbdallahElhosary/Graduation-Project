namespace NewProject.Services
{
    public class VendorService : IVendorService
    {
        private readonly AppDbContext _Context;
        public VendorService(AppDbContext context)
        {
            _Context = context;
        }

        public IEnumerable<SelectListItem> GetVendors()
        {
            return _Context.Vendors.Select(x=>new SelectListItem { Value = x.id.ToString() , Text = x.Name})
                .OrderBy(x=>x.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
