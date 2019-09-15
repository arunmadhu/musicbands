using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using musicbands.Controllers;
using musicbands.Models.ui;
using musicbands.services;
using System.Collections.Generic;

namespace UnitTestCases
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IFestivalServices> festivalService;
        private HomeController homeController;

        [TestInitialize]
        public void MyTestInitialize()
        {
            festivalService = new Mock<IFestivalServices>();
            homeController = new HomeController(festivalService.Object);
        }

        [TestMethod]
        public void GetTreeDataTest()
        {
            var festivals = new List<Festival>();
            festivals.Add(new Festival { Id = 10, Name = "Test Band" , Bands = new List<Band>()});

            festivalService.Setup(fs => fs.GetFestivals()).Returns(festivals);

            //Function call
            var result = homeController.GetTreeData();

            //Assert
            Assert.IsNotNull(result);

        }
    }
}
