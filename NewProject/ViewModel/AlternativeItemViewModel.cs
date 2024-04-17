namespace NewProject.ViewModel
{
    public class AlternativeItemViewModel
    {
        public int ValidItemId { get; set; }
        public int OfferId {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Value must be greater than 0")]
        public decimal Price { get; set; }
    }
}