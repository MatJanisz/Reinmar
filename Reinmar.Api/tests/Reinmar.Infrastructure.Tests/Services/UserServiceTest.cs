using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Helpers.Interfaces;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Tests.Services
{
    [TestFixture]
    public class UserServiceTest
    {
        private IUserService _sut;
        Mock<IUserRepository> _userRepositoryMock;
        Mock<IPasswordHelper> _passwordHelperMock;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _passwordHelperMock = new Mock<IPasswordHelper>();
            _sut = new UserService(_userRepositoryMock.Object, _passwordHelperMock.Object);
        }

        [Test]
        public void Create_Calls_Repository()
        {
            User user = new User();

            _sut.Create(user);

            _passwordHelperMock.Verify(x=>x.EncryptPassword(It.IsAny<string>()), Times.Once);
            _userRepositoryMock.Verify(x=>x.Add(It.IsAny<User>()) , Times.Once);
        }

        [Test]
        public void Delete_Calls_Repository()
        {
            User user = new User();

            _sut.Delete(user);

            _userRepositoryMock.Verify(x=>x.Delete(It.IsAny<User>()) , Times.Once);
        }

        [Test]
        public void Edit_Calls_Repository()
        {
            User user = new User();

            _sut.Update(user);

            _userRepositoryMock.Verify(x=>x.Edit(It.IsAny<User>()) , Times.Once);
        }

        [Test]
        public void GetAll_Calls_Repository()
        {
            _userRepositoryMock.Setup(x=>x.GetAll()).Returns(new List<User>());

            var result = _sut.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(0,result.Count());
        }

        [Test]
        public void GetByDomain_Calls_Repository()
        {
            string domain = "domain";
            _userRepositoryMock.Setup(x=>x.GetByDomain(It.IsAny<string>())).Returns(new User());

            var result = _sut.GetByDomain(domain);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetById_Calls_Repository()
        {
            Guid id = Guid.Empty;
            _userRepositoryMock.Setup(x=>x.GetById(It.IsAny<Guid>())).Returns(new User());

            var result = _sut.GetById(id);

            Assert.IsNotNull(result);
        }
    }
}