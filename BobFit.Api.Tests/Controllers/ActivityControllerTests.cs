using BobFit.Api.Controllers;
using NUnit.Framework;
using System.Linq;

namespace BobFit.Api.Tests.Controllers
{
    public class ActivityControllerTests
    {
        private ActivityController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new ActivityController();
        }

        [TearDown]
        public void TearDown()
        {
            _controller = null;
        }

        [Test]
        public void Get_ReturnsListOfActivities()
        {
            var activities = _controller.Get();

            Assert.True(
                activities.Value.Any()
            );
        }
    }
}
