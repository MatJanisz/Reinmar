using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Tests.Services
{
    [TestFixture]
    public class WaybillBodyServiceTest
    {
        private  IWaybillBodyService _sut;
        Mock<IWaybillBodyRepository> _waybillBodyRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _waybillBodyRepositoryMock = new Mock<IWaybillBodyRepository>();
            _sut = new WaybillBodyService(_waybillBodyRepositoryMock.Object);
        }

        [Test]
        public void Add_Calls_Repository()
        {
            WaybillBody waybillBody = new WaybillBody();

            var result = _sut.Create(waybillBody);

            Assert.NotNull(result);
            Assert.IsTrue(result.SitId > 1000000);
            Assert.IsTrue(result.SitId < 9999999);
            _waybillBodyRepositoryMock.Verify(x=>x.Add(It.IsAny<WaybillBody>()) , Times.Once);
        }

        [Test]
        public void Delete_Calls_Repository()
        {
            WaybillBody waybillBody = new WaybillBody();

            _sut.Delete(waybillBody);

            _waybillBodyRepositoryMock.Verify(x=>x.Delete(It.IsAny<WaybillBody>()) , Times.Once);
        }

        [Test]
        public void Edit_Calls_Repository()
        {
            WaybillBody waybillBody = new WaybillBody();

            _sut.Update(waybillBody);

            _waybillBodyRepositoryMock.Verify(x=>x.Edit(It.IsAny<WaybillBody>()) , Times.Once);
        }

        [Test]
        public void GetAll_Calls_Repository()
        {
            _waybillBodyRepositoryMock.Setup(x=>x.GetAll()).Returns(new List<WaybillBody>());

            var result = _sut.GetAll();

            Assert.IsNotNull(result);

            Assert.AreEqual(0,result.Count());
        }

        [Test]
        public void GetById_Calls_Repository()
        {
            Guid Id = Guid.Empty;
            _waybillBodyRepositoryMock.Setup(x=>x.GetById(It.IsAny<Guid>())).Returns(new WaybillBody());

            var result = _sut.GetById(Id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetBySitId_Calls_Repository()
        {
            int id = 1;
            _waybillBodyRepositoryMock.Setup(x=>x.GetBySitId(It.IsAny<int>())).Returns(new List<WaybillBody>());

            var result = _sut.GetBySitId(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(0,result.Count());
        }

        [Test]
        public void GetByHeaderId_Calls_Repository()
        {
            Guid Id = Guid.Empty;
            _waybillBodyRepositoryMock.Setup(x=>x.GetByHeaderId(It.IsAny<Guid>())).Returns(new List<WaybillBody>());

            var result = _sut.GetByHeaderId(Id);

            Assert.IsNotNull(result);
        }
    }
}