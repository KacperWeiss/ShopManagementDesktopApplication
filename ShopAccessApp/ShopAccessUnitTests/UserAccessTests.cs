using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopAccessApp;
using ShopAccessApp.BackEnd;

namespace ShopAccessUnitTests
{
    [TestClass]
    public class UserAccessTests
    {
        string testUsername;
        readonly users testUser;

        public UserAccessTests()
        {
            testUsername = "TestUser";
            testUser = new users()
            {
                username = testUsername,
                password = "test",
                access_level = 1
            };

            UserAccessor.CreateNew(testUser);
        }

        ~UserAccessTests() => UserAccessor.DeleteByUsername(testUsername);

        [TestMethod]
        public void SelectUserFromDataBaseTest()
        {
            Assert.AreEqual(testUser, UserAccessor.GetByUsername(testUsername));
        }
    }
}
