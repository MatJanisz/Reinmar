using System.Security;
using Moq;
using NUnit.Framework;
using Reinmar.Infrastructure.Helpers.Interfaces;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Tests.Services
{
    [TestFixture]
    public class AccountServiceTest
    {
        private  IAccountService _sut;
        Mock<IUserRepository> _userRepositoryMock;
        Mock<ITokenHelper> _tokenHelperMock;
        Mock<IPasswordHelper> _passwordHelperMock;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _tokenHelperMock = new Mock<ITokenHelper>();
            _passwordHelperMock = new Mock<IPasswordHelper>();
            _sut = new AccountService(_userRepositoryMock.Object,_tokenHelperMock.Object,_passwordHelperMock.Object);
        }

        [Test]
        public void LogIn_With_Invalid_Credentials_Throws()
        {
            string username = "username";
            string password = "password";
            _userRepositoryMock.Setup(x=>x.CheckLogIn(It.IsAny<string>(),It.IsAny<string>())).Returns(false);

            Assert.Throws<SecurityException>(()=>_sut.LogIn(username,password));
        }

        [Test]
        public void LogIn_With_Valid_Credentials_Returns_Token()
        {
            string username = "username";
            string password = "password";
            string token = "token";
            _userRepositoryMock.Setup(x=>x.CheckLogIn(It.IsAny<string>(),It.IsAny<string>())).Returns(true);
            _tokenHelperMock.Setup(x=>x.CreateToken()).Returns(token);

            var result = _sut.LogIn(username,password);

            Assert.AreEqual(token,result);
        }
    }
}