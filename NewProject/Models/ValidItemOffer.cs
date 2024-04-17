namespace NewProject.Models
{
    public class ValidItemOffer
    {
        public int ValidItemId { get; set; }
        public ValidItem ValidItem { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }

}
