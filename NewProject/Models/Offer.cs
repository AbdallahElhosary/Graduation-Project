namespace NewProject.Models
{
    public class Offer
    {
        public int id { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; } 
        public ICollection<ValidItemOffer> ValidItems { get; set; }
        public ICollection<StepnItem> StepnItems { get; set; }
    }

}
