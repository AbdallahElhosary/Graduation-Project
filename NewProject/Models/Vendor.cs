namespace NewProject.Models
{
    public class Vendor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public ICollection<Offer> offers { get; set; }
    }

}
