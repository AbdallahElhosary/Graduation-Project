namespace NewProject.Services
{
    public class NeededItemService : INeededItemService
    {
        private readonly AppDbContext _context;
        public NeededItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddNeededItem(NeededItemViewModel Model)
        {
            var LastTender = _context.Tenders.OrderBy(x=>x.Id).LastOrDefault();                
            var num = LastTender!.Id;
            NeededItem n = new()
            {
                TenderId=num,
                Name = Model.Name,
            };
            await _context.NeededItems.AddAsync(n);
            await _context.SaveChangesAsync();
        }


        public NeededItem? Edit(SpecificationNeededItemViewModel Model)
        {
            var Item = _context.NeededItems.Find(Model.id);
            if (Item == null) 
                return null;
            Item.Id = Model.id;
            Item.Name = Model.Name;
            Item.Description = Model.Description;
            Item.InitialPrice = Model.InitialPrice;
            Item.TenderId = Model.tenderId;
            Item.Type = Model.Type;
            _context.SaveChanges();
            return Item;
        }

        public IEnumerable<SpecificationNeededItemViewModel> GetAllItem()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NeededItem> GetAllLast()
        {
           var LastTender = _context.Tenders.OrderBy(x=>x.Id).LastOrDefault();
            if (LastTender == null)
                return null!;
            var n = LastTender!.Id;
            return _context.NeededItems.Include(x => x.Tender).Where(x => x.TenderId == n).ToList();
        }

        public NeededItem? GetById(int id)
        {
            return _context.NeededItems.Find(id);
        }
    }
}
