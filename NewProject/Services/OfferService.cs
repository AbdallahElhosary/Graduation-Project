namespace NewProject.Services
{
    public class OfferService : IOfferService
    {
        private readonly AppDbContext _context;
        public OfferService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(OfferViewModel model)
        {
            Offer Of = new Offer();
            Of.VendorId= model.VendorId;
            _context.Add(Of);
            _context.SaveChanges();
        }
        public Offer? LastOffer()
        {
          return _context.Offers.Include(x=>x.ValidItems).OrderBy(x=>x.id).LastOrDefault();         
        }
    //public void AddValidItemOffer(int id)
    //{
    //  Offer of = LastOffer()!;
    //  int x = of.id;
    //  ValidItemOffer validItemOffer = new ValidItemOffer();
    //  validItemOffer.OfferId = x;
    //  validItemOffer.ValidItemId = id;
    //  _context.Add(validItemOffer);
    //  _context.SaveChanges();
    //  }

      //  public IEnumerable<Offer> AllOffer()
      //  {
      //      return _context.Offers.ToList();
      //  }
        public void AddVIO(int id) 
        {
            // var Validitemid = GetValiditemByid(id);/*_context.ValidItems.Where(x=>x.NeededItemId == id).FirstOrDefault();*/
            var Validitemid = _context.ValidItems.Where(x => x.NeededItemId == id).FirstOrDefault();
            ValidItemOffer validItemOffer= new ValidItemOffer();
            var c = LastOffer();
            validItemOffer.OfferId = c!.id;
            validItemOffer.ValidItemId = Validitemid!.id;
            _context.Add(validItemOffer);
            _context.SaveChanges();
        }
        public IEnumerable<ValidItemOffer> AllValidItemOfer()
        {
            return _context.ValidItemOffers.ToList();
        }
    }
}
