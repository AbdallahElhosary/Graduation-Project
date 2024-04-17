namespace NewProject.ViewModel
{
    public class OfferViewModel
    {
        public int VendorId { get; set; }
        public IEnumerable<SelectListItem> Vendors {  get; set; } = new List<SelectListItem>();
    }
}
