using ClarkCodingChallenge.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClarkCodingChallenge.Tests.BusinessLogicTests
{
    [TestClass]
    public class ContactsBusinessLogicTests
    {
        [TestMethod]
        public void TestEmailCheck()
        {
            var goodResult = ContactsService.IsValidEmail("jsmith@gmail.com");
            var badResult = ContactsService.IsValidEmail("abcdefghi");
            Assert.AreNotEqual(goodResult, badResult);
        }
    }
}
