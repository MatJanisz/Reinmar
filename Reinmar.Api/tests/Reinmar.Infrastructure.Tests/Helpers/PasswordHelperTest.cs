using NUnit.Framework;
using Reinmar.Infrastructure.Helpers;
using Reinmar.Infrastructure.Helpers.Interfaces;

namespace Reinmar.Infrastructure.Tests.Helpers
{
    [TestFixture]
    public class PasswordHelperTest
    {
        private IPasswordHelper _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PasswordHelper();
        }

        [Test]
        public void EncryptPassword_Returns_Valid_EncryptedPassword()
        {
            string password = "password";
            string encryptedPassword = "5F4DCC3B5AA765D61D8327DEB882CF99";

            var result = _sut.EncryptPassword(password);

            Assert.AreEqual(encryptedPassword, result);
        }
    }
}