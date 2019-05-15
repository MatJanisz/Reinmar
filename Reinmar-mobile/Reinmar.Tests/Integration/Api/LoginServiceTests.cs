using AutoFixture;
using NUnit.Framework;
using Moq;
using Reinmar.Service;
using System.Threading.Tasks;
using Reinmar.ApiModel;

namespace Reinmar.Tests.Integration.Api
{
    [TestFixture]
    public class LoginServiceTests
    {
        private LoginService _sut;
        private IFixture _mockFixture;

        [SetUp]
        public void SetUp()
        {
            _mockFixture = new Fixture();
            _sut = _mockFixture.Create<Mock<LoginService>>().Object;
        }

        [Test]
        public void LogIn_WhenCorrectData_RetursTokenAsync()
        {
            //arrange
            string login = "admin";
            string password = "admin123.";

            //act
            var response = _sut.Login(login, password);
            response.Wait();
            var result = response.Result;

            //assert
            Assert.AreEqual(typeof(LoginResponse), result.GetType());
        }
    }
}
