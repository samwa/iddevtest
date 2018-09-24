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
                .UseInMemoryDatabase(databaseName: "Controller_Returns_Results")
                .Options;
            using (var context = new LgaContext(options))
            {
                
                context.Lgas.Add(new LgaModel { Place = "Albury (C)", State = "New South Wales", SEIFADisadvantage2011 = 979, SEIFADisadvantage2016 = 971 });
                context.Lgas.Add(new LgaModel { Place = "Alpine (S)", State = "Victoria", SEIFADisadvantage2011 = 987, SEIFADisadvantage2016 = 994 });
                context.Lgas.Add(new LgaModel { Place = "Aurukun (S)", State = "Queensland", SEIFADisadvantage2011 = 483, SEIFADisadvantage2016 = 504 });
                context.SaveChanges();

                LgaController = new LgaController(context);
            }
        }

        [Test]
        public void LgaController_HasResultsForNSW()
        {
            var actionResult = LgaController.Get("nsw");
            Assert.That(actionResult.Value, Is.Not.Null);
            Assert.That(actionResult.Value, Has.Count.GreaterThan(0));
        }

        [Test]
        public void LgaController_HasNoResultsForSA()
        {
            var actionResult = LgaController.Get("sa");
            Assert.That(actionResult.Value, Is.Not.Null);
            Assert.That(actionResult.Value, Has.Count.EqualTo(0));
        }
    }
}