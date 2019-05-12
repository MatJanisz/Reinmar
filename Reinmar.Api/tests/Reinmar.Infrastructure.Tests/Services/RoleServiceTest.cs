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
    public class RoleServiceTest
    {
        private  IRoleService _sut;
        Mock<IRoleRepository> _roleRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _roleRepositoryMock = new Mock<IRoleRepository>();
            _sut = new RoleService(_roleRepositoryMock.Object);
        }

        [Test]
        public void Add_Calls_Repository()
        {
            Role role = new Role();

            _sut.Add(role);

            _roleRepositoryMock.Verify(x=>x.Add(It.IsAny<Role>()) , Times.Once);
        }

        [Test]
        public void Delete_Calls_Repository()
        {
            Role role = new Role();

            _sut.Delete(role);

            _roleRepositoryMock.Verify(x=>x.Delete(It.IsAny<Role>()) , Times.Once);
        }

        [Test]
        public void Edit_Calls_Repository()
        {
            Role role = new Role();

            _sut.Edit(role);

            _roleRepositoryMock.Verify(x=>x.Edit(It.IsAny<Role>()) , Times.Once);
        }

        [Test]
        public void GetAll_Calls_Repository()
        {
            _roleRepositoryMock.Setup(x=>x.GetAll()).Returns(new List<Role>());

            var result = _sut.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(0,result.Count());
        }

        [Test]
        public void GetByDomain_Calls_Repository()
        {
            string domain = "domain";
            _roleRepositoryMock.Setup(x=>x.GetByDomain(It.IsAny<string>())).Returns(new List<Role>());

            var result = _sut.GetByDomain(domain);

            Assert.IsNotNull(result);
            Assert.AreEqual(0,result.Count());
        }

        [Test]
        public void GetById_Calls_Repository()
        {
            int id = 1;
            _roleRepositoryMock.Setup(x=>x.GetById(It.IsAny<int>())).Returns(new Role());

            var result = _sut.GetById(id);

            Assert.IsNotNull(result);
        }
    }
}