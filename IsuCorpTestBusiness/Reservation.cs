namespace IsuCorpTestBusiness
{
    public class Reservation : IsuCorpTestRepository.ReservationRepository<IsuCorpTestData.Models.Reservation>
    {
        IsuCorpTestData.Context.IsuCorpTestContext context;
        public Reservation(IsuCorpTestData.Context.IsuCorpTestContext context) : base(context)
        {
            this.context = context;
        }
    }
}
