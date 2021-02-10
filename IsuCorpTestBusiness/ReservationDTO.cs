namespace IsuCorpTestBusiness
{
    public class ReservationDTO : IsuCorpTestRepository.ReservationDTORepository<IsuCorpTestData.Models.ReservationDTO>
    {
        IsuCorpTestData.Context.IsuCorpTestContext context;
        public ReservationDTO(IsuCorpTestData.Context.IsuCorpTestContext context) : base(context)
        {
            this.context = context;
        }
    }
}
