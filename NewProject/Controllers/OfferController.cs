namespace NewProject.Controllers
{
    public class OfferController : Controller
    {
        private readonly IValidItemService _validItemService;
        private readonly IVendorService _vendorService;
        private readonly IOfferService _offerService;
        private readonly INeededItemService _neededItemService;
        public OfferController(IValidItemService validItemService , IVendorService vendorService 
            , IOfferService offerService , INeededItemService neededItemService)
        {
            _validItemService = validItemService;
            _vendorService = vendorService;
            _offerService = offerService;
            _neededItemService = neededItemService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add() 
        {
            OfferViewModel model = new OfferViewModel();
            model.Vendors = _vendorService.GetVendors();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(OfferViewModel model)
        { 
            if (!ModelState.IsValid)
            {
                return View(model);
            }
             _offerService.Add(model);

            return RedirectToAction("Items");
            
        }
        public IActionResult Items() //to show item that sended to vendors 
        {
            IEnumerable<NeededItem> NeededItems = _neededItemService.GetAllLast();
            IEnumerable<ValidItem> ListNeeded = _validItemService.ValidItems();
            List<NeededItem> NI = new List<NeededItem>();
            foreach (NeededItem neededItem in NeededItems)
            {
                var n = neededItem.Id;
                foreach (var valid in ListNeeded)
                {
                    var v = valid.NeededItemId;
                    if (n == v)
                    {
                        NI.Add(neededItem);
                    }
                }
            }
            return View(NI);
        } 
    }
}
