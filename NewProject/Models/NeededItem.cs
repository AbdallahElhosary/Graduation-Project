namespace NewProject.Models
{
    public class NeededItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public int InitialPrice {  get; set; }
        public int TenderId {  get; set; }
        public Tender Tender { get; set; }
    }
}
