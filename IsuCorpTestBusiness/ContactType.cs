namespace IsuCorpTestBusiness
{
    public class ContactType : IsuCorpTestRepository.ContactTypeRepository<IsuCorpTestData.Models.ContactType>
    {
        IsuCorpTestData.Context.IsuCorpTestContext context;
        public ContactType(IsuCorpTestData.Context.IsuCorpTestContext context) : base(context)
        {
            this.context = context;
        }
    }
}
