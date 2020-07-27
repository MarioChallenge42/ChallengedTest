using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Challenged.Infrastructure.Contracts;
using Challenged.Infrastructure.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebChallenged;
using WebChallenged.Controllers;

namespace WebChallenged.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        private static IRepository _Repository;

        [TestInitialize]
        public  void SetupTests()
        {
            _Repository =new Repository();
           
        }

        [TestMethod]
        public async Task Index()
        {
            // Arrange
            HomeController controller = new HomeController(_Repository);

            // Act
            ViewResult result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(_Repository);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(_Repository);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
