using Microsoft.AspNetCore.Mvc;

namespace NewProject.Controllers
{
    public class StepnItemController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly IValidItemService _validItemService;
        private readonly IAlternativeItemService _alternativeItemService;
        public StepnItemController(IOfferService offerService, IValidItemService validItemService, IAlternativeItemService alternativeItemService)
        {
            _offerService = offerService;
            _validItemService = validItemService;
            _alternativeItemService = alternativeItemService;
        }

        public IActionResult Index()
        {
            return View();
        } //not used yet
        public IActionResult AddAlternativeItems(int id)                                //id => for needed item 
        {
            var Lastoffer = _offerService.LastOffer();                                  //var LOID = Lastoffer!.id;
            var currentitem = _validItemService.GetValiditemByneededitemid(id);         // var CI = currentitem.id;

            AlternativeItemViewModel AVM = new AlternativeItemViewModel();
            IEnumerable<ValidItemOffer> VIOO = _offerService.AllValidItemOfer();
            // عشان يسجل العنصر دا مع العرض لو كان متسجلش
            foreach (var i in VIOO)
            {
                if (i.OfferId == Lastoffer!.id && i.ValidItemId == currentitem!.id)
                {
                    AVM.ValidItemId = currentitem!.id;
                    AVM.OfferId = Lastoffer.id;
                    return View(AVM);
                }
            }
            AVM.ValidItemId = currentitem!.id;
            AVM.OfferId = Lastoffer!.id;
            _offerService.AddVIO(id);
            return View(AVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAlternativeItems(AlternativeItemViewModel SI)
        {

            if (!ModelState.IsValid)
            {
                return View(SI);
            }
            _alternativeItemService.Add(SI);
            AlternativeItemViewModel STI = new()
            {
                ValidItemId = SI.ValidItemId,
                OfferId = SI.OfferId,
            };
            return RedirectToAction("AddAlternativeItems" , STI);
        }
    }
}
