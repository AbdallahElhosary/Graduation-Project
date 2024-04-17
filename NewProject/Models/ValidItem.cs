namespace NewProject.Models
{
    public class ValidItem
    {
        public int id { get; set; }
        public int NeededItemId { get; set; }
        public NeededItem NeededItem { get; set; }
        public ICollection<ValidItemOffer> offers  { get; set; }
        public ICollection<StepnItem> StepnItems {  get; set; }
    }

}
