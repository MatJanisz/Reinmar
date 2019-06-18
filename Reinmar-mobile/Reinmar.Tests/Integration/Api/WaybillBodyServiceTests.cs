using System;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Reinmar.Common.Entities;
using Reinmar.Service;

namespace Reinmar.Tests.Integration.Api
{
    [TestFixture]
    public class WaybillBodyServiceTests
    {
        private WaybillBodyService _sut;
        private LoginService _loginService;
        private IFixture _mockFixture;
        private string token;

        [SetUp]
        public void SetUp()
        {
            _mockFixture = new Fixture();
            _sut = _mockFixture.Create<Mock<WaybillBodyService>>().Object;
            _loginService = _mockFixture.Create<Mock<LoginService>>().Object;
            token = GetToken().Result;
        }

        [Test]
        public void GetWaybillBody_WhenCorrectData_RetursWaybillBodyAsync()
        {
            //arrange
            int sitId = 4632481;

            //act
            var response = _sut.GetWaybillBody(sitId, token);
            response.Wait();
            var result = response.Result;

            //assert
            Assert.AreEqual(typeof(WaybillBody), result.GetType());
            Assert.IsNotNull(result);
        }

        private async Task<string> GetToken()
        {
            var loginResponse = _loginService.Login("admin", "admin123.");
            loginResponse.Wait();
            return loginResponse.Result.Token;
        }
    }
}
