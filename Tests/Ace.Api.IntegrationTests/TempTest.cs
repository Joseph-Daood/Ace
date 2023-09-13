using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ace.Api.IntegrationTests
{
    [TestClass]
    public class TempTest
    {
        private WebApplicationFactory<Program> _factory;//= new WebApplicationFactory<Program>();
        private HttpClient _client;//= _factory.CreateClient();

        [TestInitialize]
        public void Initialize()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestMethod]
        public void OnlyForTest()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
