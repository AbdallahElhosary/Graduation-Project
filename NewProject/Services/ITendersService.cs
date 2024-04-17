namespace NewProject.Services
{
    public interface ITendersService
    {
        IEnumerable<Tender> GetAll();
        Task AddTender(TenderViewModel tender);
        Tender? GetLastTender();
    }
}
