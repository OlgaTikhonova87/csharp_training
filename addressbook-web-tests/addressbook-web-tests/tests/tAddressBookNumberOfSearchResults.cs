using NUnit.Framework;

namespace WebAddressbookTests
    
{
    [TestFixture]
    class NumberOfSearchResultsTest : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            System.Console.Write(app.Address.GetNumberOfSearchResults());
        }

    }
}
