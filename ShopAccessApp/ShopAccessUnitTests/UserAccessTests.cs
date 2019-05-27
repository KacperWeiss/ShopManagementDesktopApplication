using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopAccessApp;
using ShopAccessApp.BackEnd;

namespace ShopAccessUnitTests
{
    [TestClass]
    public class UserAccessTests
    {
        UserAccess access;
        string testUsername;
        readonly users testUser;

        public UserAccessTests()
        {
            access = new UserAccess();
            testUsername = "TestUser";
            testUser = new users()
            {
                username = testUsername,
                password = "test",
                access_level = 1
            };

            access.CreateNewUser(testUser);
        }

        ~UserAccessTests() => access.DeleteUserByUsername(testUsername);

        [TestMethod]
        public void SelectUserFromDataBaseTest()
        {
            Assert.AreEqual(testUser, access.GetUserByUsername(testUsername));
        }
    }
}
