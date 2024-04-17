namespace NewProject.Services
{
    public class ValidItemService : IValidItemService
    {
        private readonly AppDbContext _context;
        private readonly IOfferService _offerService;
        public ValidItemService(AppDbContext context , IOfferService offerService)
        {
            _context = context;
            _offerService = offerService;
        }
        public ValidItem? GetById(int id)
        {
            return _context.ValidItems.Include(x=>x.StepnItems).FirstOrDefault(z=>z.id==id);
        }
        public ValidItem? GetValiditemByneededitemid(int id)
        {
            return _context.ValidItems.Where(x => x.NeededItemId == id).FirstOrDefault();
        }
        public async Task ValidItem(int id)
        {
            
            ValidItem V = new ValidItem();
            V.NeededItemId = id;
            await _context.AddAsync(V);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<ValidItem> ValidItems()
        {
            return _context.ValidItems.Include(x=>x.NeededItem).ToList();
        }
        public IEnumerable<SelectListItem> GetValidItems()
        {
            var tenderid = _context.Tenders.OrderBy(x=>x.Id).LastOrDefault();
            if (tenderid == null)
                return null!;
            var TId = tenderid.Id;
            return _context.ValidItems.Include(x => x.NeededItem).Where(x => x.NeededItem.TenderId == TId).Select(x => new SelectListItem { Value = x.id.ToString(), Text=x.NeededItem.Name })
                .AsNoTracking()
                .OrderBy(x => x.Text)
                .ToList();
        }
    }
}
