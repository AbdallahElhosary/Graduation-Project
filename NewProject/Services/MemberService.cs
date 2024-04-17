namespace NewProject.Services
{
    public class MemberService : IMemberService
    {
        private readonly AppDbContext _context;
        public MemberService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetMembers()
        {
            return _context.Members.Where(x => x.Password != null)
                .Select(x=>new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .AsNoTracking()
                .OrderBy(x=>x.Text)
                .ToList();
        }
    }
       

}
