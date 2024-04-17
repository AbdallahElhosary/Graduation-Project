namespace NewProject.Services
{
    public class TendersService : ITendersService
    {
        private readonly AppDbContext _context;
        public TendersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddTender(TenderViewModel tender)
        {
            Tender T = new()
            {
                Name = tender.Title,
                DateOnly = tender.DateOnly,
                Description = tender.Description,
            };
            await _context.AddAsync(T);
            await _context.SaveChangesAsync();          

        }

        public IEnumerable<Tender> GetAll()
        {
            IEnumerable<Tender> Tenders = _context.Tenders.ToList();
            return Tenders;
        }

        public Tender? GetLastTender() => _context.Tenders.OrderBy(x=>x.Id).LastOrDefault();
    }
}
