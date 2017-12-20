using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//additional reference 
using Assign2part1.Controllers;
using System.Web.Mvc;
using Moq;
using Assign2part1.Models;
using System.Linq;

namespace Assign2part1.Tests.Controllers
{

    [TestClass]
    public class BreweriesControllerTest
    {
        breweriesController controller;
        Mock<IbreweriesRepository> mock;
        List<brewery> breweries;

        [TestInitialize]
        public void TestIninitalize()
        {
            //arrange 
            mock = new Mock<IbreweriesRepository>();

            breweries = new List<brewery>
            {
                new brewery { breweryID = 1, breweryLocation = "Barrie", breweryName = "Monkey", features = "Patio"},
                new brewery { breweryID = 2, breweryLocation = "North York", breweryName = "Cannon", features = "Samples"},
                new brewery { breweryID = 3, breweryLocation = "Toronto", breweryName = "British Arms", features = "Patio and samples"}
            };

            // populate the mock object with our sample data
            mock.Setup(m => m.Breweries).Returns(breweries.AsQueryable());
            //pass the mock into the second constructor
            controller = new breweriesController(mock.Object);
        }

        [TestMethod]
        public void IndexViewLoads()
        {
            // Arrange


            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexReturnsBrewery()
        {
            // Act

            var actual = (List<brewery>)controller.Index().Model;

            // Assert
            // check if the list returned in the view matches the list we passed in to the mock
            CollectionAssert.AreEqual(breweries, actual);
        }

        [TestMethod]
        public void DetailsValidBrewery()
        {
            // Act
            var actual = (brewery)controller.Details(1).Model;

            // Assert
            Assert.AreEqual(breweries.ToList()[0], actual);
        }

        [TestMethod]
        public void DetailsInvalidBrewery()
        {
            // Act
            var actual = (brewery)controller.Details(123).Model;

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void DetailsInvalidNoId()
        {
            // Arrange
            int? id = null;

            // Act
            var actual = controller.Details(id);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // GET: Edit
        [TestMethod]
        public void EditBreweryValid()
        {
            // ACT
            var actual = (brewery)controller.Edit(1).Model;

            // ASSERT
            Assert.AreEqual(breweries.ToList()[0], actual);
        }
        [TestMethod]
        public void EditInvalidNoId()
        {
            //arrange
            int? id = null;

            //act
            var actual = (ViewResult)controller.Edit(id);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void EditInvalidBreweryId()
        {
            // Act
            ViewResult result = controller.Edit(-314) as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        // GET: Delete
        [TestMethod]
        public void DeleteValidBrewery()
        {
            // Act            
            var actual = (brewery)controller.Delete(1).Model;

            // Assert            
            Assert.AreEqual(breweries.ToList()[0], actual);
        }
        // Delete invalid ID test
        [TestMethod]
        public void DeleteInvalidBreweryId()
        {
            // Arrange
            int id = 87656765;

            // Act
            ViewResult actual = (ViewResult)controller.Delete(id);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DeleteInvalidNoId()
        {
            // arrange           
            int? id = null;

            // act           
            ViewResult actual = controller.Delete(id);

            // assert           
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void CreateViewLoads()
        {
            // act - cast the return type as ViewResult
            ViewResult actual = (ViewResult)controller.Create();

            // assert
            Assert.AreEqual("Create", actual.ViewName);
            Assert.IsNotNull(actual.ViewBag.breweryID);
        }
        // POST: Create
        [TestMethod]
        public void CreateValidBrewery()
        {
            // arrange
            brewery breweries = new brewery
            {
                breweryID = 4,
                breweryLocation = "Canada", 
                breweryName = "Moose", 
                features = "patio"
            };

            // act
            RedirectToRouteResult actual = (RedirectToRouteResult)controller.Create(breweries);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        [TestMethod]
        public void CreateInvalidBrewery()
        {
            // arrange
            controller.ModelState.AddModelError("key", "error message");
            brewery breweries = new brewery
            {
                breweryID = 4,
                breweryLocation = "Canada",
                breweryName = "Moose",
                features = "patio"
            };

            // act - cast the return type as ViewResult
            ViewResult actual = (ViewResult)controller.Create(breweries);

            // assert
            Assert.AreEqual("Create", actual.ViewName);
            Assert.IsNotNull(actual.ViewBag.breweryID);
          
        }
        // POST: Edit

        [TestMethod]
        public void EditValidBrewery()
        {
            // arrange
            brewery brewery = breweries.ToList()[0];

            // act
            RedirectToRouteResult actual = (RedirectToRouteResult)controller.Edit(brewery);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }
        // POST: DeleteConfirmed
        [TestMethod]
        public void DeleteConfirmedValidAlbum()
        {
            // Act            
            RedirectToRouteResult actual = (RedirectToRouteResult)controller.DeleteConfirmed(1);

            // Assert            
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        // Delete invalid ID test
        [TestMethod]
        public void DeleteConfirmedInvalidAlbumId()
        {
            // Arrange
            int id = 87656765;

            // Act
            ViewResult actual = (ViewResult)controller.DeleteConfirmed(id);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedInvalidNoId()
        {
            // arrange           
            int? id = null;

            // act           
            ViewResult actual = controller.DeleteConfirmed(id);

            // assert           
            Assert.AreEqual("Error", actual.ViewName);
        }

    }
}

        