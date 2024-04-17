namespace NewProject.Controllers
{
    public class NeededItemController : Controller
    {
        private readonly INeededItemService _neededItemService;
        public NeededItemController(INeededItemService neededItemService)
        {
            _neededItemService = neededItemService;
        }
        public IActionResult Index()
        {
            return View(_neededItemService.GetAllLast());
        }
        public IActionResult AddNeededItem()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNeededItem(NeededItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _neededItemService.AddNeededItem(model);
            return RedirectToAction("AddNeededItem");
        }

        //for add Specification and price to Tender's Item
        public IActionResult Edit(int id)
        {
            var Item = _neededItemService.GetById(id);
            if (Item == null)
                return BadRequest();
            SpecificationNeededItemViewModel p = new SpecificationNeededItemViewModel();
            p.tenderId = Item.TenderId;
            p.id = Item.Id;
            p.Description = Item.Description;
            p.Type = Item.Type;
            p.Name = Item.Name;
            p.InitialPrice= Item.InitialPrice;         
            return View(p);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SpecificationNeededItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var n = _neededItemService.Edit(model);
            if (n == null)
                return BadRequest();
            //to go back for needed item and add sp.... and price for ather item
            return RedirectToAction(nameof(Index));
        }


    }
}
