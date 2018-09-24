using NUnit.Framework;
using iddevtest.Controllers;
using Microsoft.EntityFrameworkCore;

namespace iddevtest.Tests
{
    public class LgaControllerTests
    {
        public LgaController LgaController { get; set; }
        [SetUp]
        public void Setup()
        {
            
            var options = new DbContextOptionsBuilder<LgaContext>()
                .UseInMemoryDatabase(databaseName: "Find_searches_url")
                .Options;
            using (var context = new LgaContext(options))
            {
                var LgaController = new LgaController(context);
            }
        }

        [Test]
        public void LgaController_IsIndex()
        {
            var actionResult = LgaController.Get("nsw");
            Assert.That(actionResult.Result, Has.Count.GreaterThan(0));
            //Assert.Fail();
        }
    }
}