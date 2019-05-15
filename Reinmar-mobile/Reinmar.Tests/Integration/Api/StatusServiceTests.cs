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
    public class StatusServiceTests
    {
        private StatusService _sut;
        private LoginService _loginService;
        private WaybillBodyService _waybillBodyService;
        private IFixture _mockFixture;
        private string _token;
        private int _sitId = 4632481;

        [SetUp]
        public void SetUp()
        {
            _mockFixture = new Fixture();
            _waybillBodyService = _mockFixture.Create<Mock<WaybillBodyService>>().Object;
            _loginService = _mockFixture.Create<Mock<LoginService>>().Object;
            _mockFixture = new Fixture();
            _sut = _mockFixture.Create<Mock<StatusService>>().Object;
            _token = GetToken().Result;
        }

        [Test]
        public void AddStatus_WhenCorrectData_RetursStatusOk()
        {
            //arrange
            var waybillBody = GetWaybillBody(_sitId, _token).Result;

            //act
            var response = _sut.AddStatus(waybillBody, Enums.StatusEvent.Delivered, _token);
            response.Wait();

            //assert
            Assert.AreEqual(response.Result, Enums.Status.Ok);
        }

        private async Task<string> GetToken()
        {
            var loginResponse = _loginService.Login("admin", "admin123.");
            loginResponse.Wait();
            return loginResponse.Result.Token;
        }

        private async Task<WaybillBody> GetWaybillBody(int sitId, string token)
        {
            var waybillBodyResponse = _waybillBodyService.GetWaybillBody(sitId, token);
            waybillBodyResponse.Wait();
            return waybillBodyResponse.Result;
        }
    }
}
