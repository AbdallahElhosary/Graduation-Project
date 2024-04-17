namespace NewProject.Models
{
    public class StepnItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int ValidItemId {  get; set; }
        public ValidItem ValidItem { get; set; }
        public int OfferId {  get; set; }
        public Offer Offer { get; set; }
        public AcceptedItem AcceptedItem { get; set; }
    }

}
