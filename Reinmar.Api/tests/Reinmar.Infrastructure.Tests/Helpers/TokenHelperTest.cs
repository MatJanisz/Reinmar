using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using Reinmar.Infrastructure.Helpers;
using Reinmar.Infrastructure.Helpers.Interfaces;

namespace Reinmar.Infrastructure.Tests.Helpers
{
    [TestFixture]
    public class TokenHelperTest
    {
        private  ITokenHelper _sut;
        Mock<IConfiguration> _configurationMock;

        [SetUp]
        public void SetUp()
        {
            _configurationMock = new Mock<IConfiguration>();
            _sut = new TokenHelper(_configurationMock.Object);
        }
    }
}