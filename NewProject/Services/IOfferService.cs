namespace NewProject.Services
{
    public interface IOfferService
    {
        void Add(OfferViewModel model);//okk
        //void AddValidItemOffer(int id);//ok
        //IEnumerable<Offer> AllOffer();//no
        Offer? LastOffer();//okk
        void AddVIO(int id);//okk
        IEnumerable<ValidItemOffer> AllValidItemOfer();//okk
    }
}
