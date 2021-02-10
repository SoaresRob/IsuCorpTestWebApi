namespace IsuCorpTestBusiness
{
    public class ContactDTO : IsuCorpTestRepository.ContactDTORepository<IsuCorpTestData.Models.ContactDTO>
    {
        IsuCorpTestData.Context.IsuCorpTestContext context;
        public ContactDTO(IsuCorpTestData.Context.IsuCorpTestContext context) : base(context)
        {
            this.context = context;
        }
    }
}
