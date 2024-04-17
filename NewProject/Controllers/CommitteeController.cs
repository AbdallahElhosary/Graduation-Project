namespace NewProject.Controllers
{
    public class CommitteeController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ITendersService _TendersService;
        private readonly ICommitteeService _committeeService;
       public CommitteeController(IMemberService memberService, ICommitteeService committeeService , ITendersService tendersService)
        {
            _memberService = memberService;
            _committeeService = committeeService;
            _TendersService = tendersService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LastSLCMembers()
        {
            var slc = _committeeService.GetBySelectionCommitteeId();
            return View(slc);
        }
        public IActionResult LastSPCMembers()
        {
            var SPC = _committeeService.GetBySpecifictionCommitteeID();
            return View(SPC);
        }
        public IActionResult LastTECMembers()
        {
            var TEC = _committeeService.GetByTechnicalCommitteeId();
            return View(TEC);
        }
        public IActionResult DeterminCommitteeMembers()
        {
            CommitteeViewModel viewModel = new CommitteeViewModel();
            viewModel.Memebers = _memberService.GetMembers();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeterminCommitteeMembers(CommitteeViewModel model)
        {
            if(!ModelState.IsValid)
            {
                CommitteeViewModel viewModel = new CommitteeViewModel();
                viewModel.Memebers = _memberService.GetMembers();
                return View(viewModel);
            }
            await _committeeService.AddCommitteeMembers(model);
            return RedirectToAction("index" , "Home");
        }
    }
    
}
