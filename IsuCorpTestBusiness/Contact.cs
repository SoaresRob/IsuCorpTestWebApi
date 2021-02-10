namespace IsuCorpTestBusiness
{
    public class Contact : IsuCorpTestRepository.ContactRepository<IsuCorpTestData.Models.Contact>
    {
        IsuCorpTestData.Context.IsuCorpTestContext context;
        public Contact(IsuCorpTestData.Context.IsuCorpTestContext context) : base(context)
        {
            this.context = context;
        }
    }
}
