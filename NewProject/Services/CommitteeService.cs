namespace NewProject.Services
{
    public class CommitteeService : ICommitteeService
    {
        private readonly AppDbContext _context;
        public CommitteeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCommitteeMembers(CommitteeViewModel model)
        {
            var LastTender = _context.Tenders.OrderBy(x => x.Id).LastOrDefault();
            var n = LastTender!.Id;
            SelectionCommittee SLC = new()
            {
                TenderId = n,
                Members = model.SelectSLCMembers.Select(x => new SelectionCommitteeMember { MemberId = x }).ToList()
            };
            await _context.AddAsync(SLC);
            SpecifictionCommittee SPC = new()
            {
                TenderId = n,
                Members = model.SelectSPCMembers.Select(x => new SpecifictionCommitteeMember { MemberId = x }).ToList()
            };
            await _context.AddAsync(SPC);
            TechnicalCommittee Technical = new()
            {
                TenderId = n,
                Members = model.SelectTECMembers.Select(x => new TechnicalCommitteeMember { MemberId = x }).ToList()
            };
            await _context.AddAsync(Technical);
            await _context.SaveChangesAsync();
        }
        
        public SelectionCommittee GetBySelectionCommitteeId()
        {
            SelectionCommittee? S = _context.SelectionCommittees.Include(x=>x.Members).ThenInclude(x=>x.Member).OrderBy(x=>x.Id).LastOrDefault();
            if (S == null)
                return null!;
            return S;
        }

        public SpecifictionCommittee GetBySpecifictionCommitteeID()
        {
            SpecifictionCommittee? S = _context.SpecifictionCommittees.Include(x => x.Members).ThenInclude(x=>x.Member).OrderBy(x=>x.Id).LastOrDefault();
            if (S == null)
                return null!;
            return S;
        }

        public TechnicalCommittee GetByTechnicalCommitteeId()
        {
            TechnicalCommittee? S = _context.TechnicalCommittees.Include(x => x.Members).ThenInclude(x => x.Member).OrderBy(x=>x.Id).LastOrDefault();
            if (S == null)
                return null!;
            return S;
        }
    }
}
