namespace NewProject.Models
{
    public class AcceptedItem
    {
        public int id { get; set; }
        public int Num { get; set; }    
        public int StepnItemId { get; set; }
        public StepnItem StepnItem { get; set; }
    }

}
