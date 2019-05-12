using System;
using Moq;
using NUnit.Framework;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Tests.Services
{
    [TestFixture]
    public class WaybillServiceTest
    {
        private  IWaybillService _sut;
        Mock<IWaybillRepository> _waybillRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _waybillRepositoryMock = new Mock<IWaybillRepository>();
            _sut = new WaybillService(_waybillRepositoryMock.Object);
        }

        [Test]
        public void Create_Calls_Repository()
        {
            Waybill waybill = new Waybill();

            _sut.Create(waybill);

            _waybillRepositoryMock.Verify(x=>x.Add(It.IsAny<Waybill>()),Times.Once);
        }

        [Test]
        public void GetWaybillsById_Calls_Repository()
        {
            Guid id = Guid.Empty;
            _waybillRepositoryMock.Setup(x=>x.GetById(It.IsAny<Guid>())).Returns(new Waybill());

            var result = _sut.GetWaybillsById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetWaybillsBySitId_Calls_Repository()
        {
            int id = 1;
            _waybillRepositoryMock.Setup(x=>x.GetBySitId(It.IsAny<int>())).Returns(new Waybill());

            var result = _sut.GetWaybillsBySitId(id);

            Assert.IsNotNull(result);
        }
    }
}