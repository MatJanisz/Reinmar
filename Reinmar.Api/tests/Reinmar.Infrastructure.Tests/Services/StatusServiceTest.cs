using Moq;
using NUnit.Framework;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Tests.Services
{
    [TestFixture]
    public class StatusServiceTest
    {
        private  IStatusService _sut;
        Mock<IStatusRepository> _statusRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _statusRepositoryMock = new Mock<IStatusRepository>();
            _sut = new StatusService(_statusRepositoryMock.Object);
        }

        [Test]
        public void Add_Calls_Repository()
        {
            Status status = new Status();

            _sut.Add(status);

            _statusRepositoryMock.Verify(x=>x.Add(It.IsAny<Status>()) , Times.Once);
        }


        [Test]
        public void Edit_Calls_Repository()
        {
            Status status = new Status();

            _sut.Edit(status);

            _statusRepositoryMock.Verify(x=>x.Edit(It.IsAny<Status>()) , Times.Once);
        }
    }
}