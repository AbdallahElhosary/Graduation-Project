namespace NewProject.ViewModel
{
    public class CommitteeViewModel
    {
        [Display(Name = "Specification And Pricing Committee Members")]
        public List<int> SelectSPCMembers { get; set; } = default!;
        [Display(Name = "Selection Committee Members")]
        public List<int> SelectSLCMembers { get; set; } = default!;
        [Display(Name = "Technical Committee Members")]
        public List<int> SelectTECMembers { get; set; } = default!;
        public IEnumerable<SelectListItem> Memebers { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
