namespace NewProject.Controllers
{
    public class ValidItemController : Controller
    {
        private readonly INeededItemService _neededItemService;
        private readonly IValidItemService _validItemService;
        public ValidItemController(INeededItemService neededItemService , IValidItemService validItemService)
        {
            _neededItemService = neededItemService;
            _validItemService = validItemService;
        }

        public IActionResult Index()
        {
            IEnumerable<NeededItem> NeededItems = _neededItemService.GetAllLast();
            IEnumerable<ValidItem> ListNeeded = _validItemService.ValidItems();
            List<NeededItem> NI  = new List<NeededItem>();
            foreach (NeededItem neededItem in NeededItems)
            {
                var n = neededItem.Id;
                foreach(var valid in ListNeeded)
                {
                    var v = valid.NeededItemId;
                    if(n == v)
                    {
                        NI.Add(neededItem);
                    }
                }
            }
            return View(NI);
        }
        public IActionResult ChooseValidItem() 
        {
            var items = _neededItemService.GetAllLast();
            return View(items);
        }
      //  [HttpPost]
        public async Task<IActionResult> Add(int Id) 
        {
            var item = _neededItemService.GetById(Id);
            if (item == null)
                return BadRequest();
            IEnumerable<ValidItem> ListNeeded = _validItemService.ValidItems();
            foreach (var i in ListNeeded)
            {
                if (i.NeededItemId == item.Id)
                {
                    return Content("This item is alredy added");
                }
            }
            await _validItemService.ValidItem(Id);
            return RedirectToAction("Index");
        }
    }
}
