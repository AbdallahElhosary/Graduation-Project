namespace NewProject.Controllers
{
    public class TenderController : Controller
    {
        private readonly ITendersService _tendersService;
       
        public TenderController (ITendersService tendersService )
        {
            _tendersService = tendersService;
        }
        public IActionResult ShowTender()
        {
            return View(_tendersService.GetAll());
        }
        public IActionResult CreateTender()
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTender(TenderViewModel model)
        {
            if(!ModelState.IsValid)
            {
               
                return View(model);
            }
            await _tendersService.AddTender(model);
            return RedirectToAction("AddNeededItem" , "NeededItem");
        }
    }
}
