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
    public class WaybillHeaderServiceTest
    {
        private  IWaybillHeaderService _sut;
        Mock<IWaybillHeaderRepository> _waybillHeaderRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _waybillHeaderRepositoryMock = new Mock<IWaybillHeaderRepository>();
            _sut = new WaybillHeaderService(_waybillHeaderRepositoryMock.Object);
        }

        [Test]
        public void Add_Calls_Repository()
        {
            WaybillHeader waybillHeader = new WaybillHeader();

            _sut.Create(waybillHeader);

            _waybillHeaderRepositoryMock.Verify(x=>x.Add(It.IsAny<WaybillHeader>()) , Times.Once);
        }

        [Test]
        public void Delete_Calls_Repository()
        {
            WaybillHeader waybillHeader = new WaybillHeader();

            _sut.Delete(waybillHeader);

            _waybillHeaderRepositoryMock.Verify(x=>x.Delete(It.IsAny<WaybillHeader>()) , Times.Once);
        }

        [Test]
        public void Edit_Calls_Repository()
        {
            WaybillHeader waybillHeader = new WaybillHeader();

            _sut.Update(waybillHeader);

            _waybillHeaderRepositoryMock.Verify(x=>x.Edit(It.IsAny<WaybillHeader>()) , Times.Once);
        }

        [Test]
        public void GetAll_Calls_Repository()
        {
            _waybillHeaderRepositoryMock.Setup(x=>x.GetAll()).Returns(new List<WaybillHeader>());

            var result = _sut.GetAll();

            Assert.IsNotNull(result);

            Assert.AreEqual(0,result.Count());
        }

        [Test]
        public void GetById_Calls_Repository()
        {
            Guid Id = Guid.Empty;
            _waybillHeaderRepositoryMock.Setup(x=>x.GetById(It.IsAny<Guid>())).Returns(new WaybillHeader());

            var result = _sut.GetById(Id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetBySitId_Calls_Repository()
        {
            int id = 1;
            _waybillHeaderRepositoryMock.Setup(x=>x.GetBySitId(It.IsAny<int>())).Returns(new WaybillHeader());

            var result = _sut.GetBySitId(id);

            Assert.IsNotNull(result);
        }
    }
}