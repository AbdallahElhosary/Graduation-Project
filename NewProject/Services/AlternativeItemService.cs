namespace NewProject.Services
{
    public class AlternativeItemService : IAlternativeItemService
    {
        private readonly AppDbContext _context;
        public AlternativeItemService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(AlternativeItemViewModel model)
        {
            StepnItem item = new StepnItem();
            item.Name = model.Name;
            item.Description = model.Description;
            item.Type = model.Type;
            item.Price = model.Price;
            item.ValidItemId = model.ValidItemId;
            item.OfferId = model.OfferId;
            _context.Add(item);
            _context.SaveChanges();            
        }

        public IEnumerable<StepnItem> GetAllByValidItemId(int id)
        {
            return _context.StepnItems.Include(x=>x.ValidItem).Where(x=>x.ValidItemId == id).ToList();
        }
    }
    public interface IAlternativeItemService
    {
        void Add(AlternativeItemViewModel model);
        IEnumerable<StepnItem> GetAllByValidItemId(int id);
    }
}
