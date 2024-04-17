using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NewProject.ViewModel
{
    public class TenderViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly DateOnly { get; set; }
       
       
    }
}
