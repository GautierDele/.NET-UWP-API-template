using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WebApp.Controllers;
using WebApp.Models.DataManager;
using WebApp.Models.EntityFramework;
using WebApp.Models.Repository;

namespace UnitTestProjectApp
{
    [TestClass]
    public class UnitTest1
    {
        private DSDBContext _context;
        private TelephoneController _controller;
        private IDataRepository<Telephone> _dataRepository;

        [TestInitialize]
        public void InitializeTest()
        {
            var builder = new DbContextOptionsBuilder<DSDBContext>().UseNpgsql("Server=localhost;port=5432;Database=DSdotnet; uid=postgres; password=postgres;");
            _context = new DSDBContext(builder.Options);
            _dataRepository = new TelephoneManager(_context);
            _controller = new TelephoneController(_dataRepository);
        }

        [TestMethod]
        public void GetAllFilm_Ok()
        {
            var got = _controller.GetAllTelephone().Result;
            var expected = _context.Telephone.ToArray();
            var gotArray = got.Value.ToArray();
            Assert.AreEqual(gotArray.Length, expected.Length, "Length are different");
            for (var i = gotArray.Length - 1; i >= 0; i--)
            {
                Assert.AreEqual(gotArray[i], expected[i], $"Item [{i}] are different");
            }
        }

        [TestMethod]
        public void GetTelephoneById_KnownId_Ok()
        {
            var got = _controller.GetTelephoneById(1).Result;
            var expected = _context.Telephone.Find(1);
            Assert.AreEqual(got.Value, expected, "Not the same objects");
        }

        [TestMethod]
        public void GetTelephoneById_UnknownId_NotFound()
        {
            var got = _controller.GetTelephoneById(-1).Result;
            Assert.IsInstanceOfType(got.Result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void GetTelephoneByReference_KnownRefrence_Ok()
        {
            var expected = _context.Telephone.Find(1);
            var got = _controller.GetTelephoneByReference(expected.Reference).Result;
            Assert.AreEqual(got.Value, expected, "Not the same objects");
        }

        [TestMethod]
        public void GetTelephoneByReference_UnknownReference_NotFound()
        {
            var got = _controller.GetTelephoneByReference("__most_likely_an_unknown_Reference__").Result;
            Assert.IsInstanceOfType(got.Result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void PutTelephone_DifferentId_BadRequest()
        {
            var telephone = new Telephone()
            {
                TelephoneId = 1,
            };
            var got = _controller.PutTelephone(5, telephone).Result;
            Assert.IsInstanceOfType(got, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void PutTelephone_ModelValidated_NotFound()
        {
            var telephone = new Telephone()
            {
                TelephoneId = -1,
            };
            var got = _controller.PutTelephone(-1, telephone).Result;
            Assert.IsInstanceOfType(got, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostTelephone_ModelValidated_CreationOK()
        {
            // Arrange
            var telephone = new Telephone()
            {
                Reference = "AZERR",
                Marque = "Apple",
                Modele = "XR743743",
                Memoire = 128,
                DateSortie = new DateTime()
            };
            // Act
            var got = _controller.PostTelephone(telephone).Result;
            var actionResult = _controller.GetTelephoneByReference(telephone.Reference).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Value, typeof(Telephone), "Not a telephone");
            var expected = _context.Telephone.Where(c => c.Reference == telephone.Reference).FirstOrDefault();

            // We don't know the ID of the created telephone, because it was generated automatically,
            // so we retrieve it from the newly created entry
            telephone.TelephoneId = expected.TelephoneId;
            Assert.AreEqual(expected, telephone, "Different telephones");
        }

        [TestMethod]
        public void DeleteTelephone_ModelValidated_DeleteOK()
        {
            Telephone toDeleteTelephone = _context.Telephone.OrderByDescending(telephone => telephone.TelephoneId).FirstOrDefault();
            var delete = _controller.DeleteTelephone(toDeleteTelephone.TelephoneId).Result;
            Assert.IsInstanceOfType(delete.Value, typeof(Telephone), "Not a telephone");
            Telephone expected = _context.Telephone.OrderByDescending(telephone => telephone.TelephoneId).FirstOrDefault();
            Assert.AreNotEqual(expected, toDeleteTelephone, "Same telephones");

        }
    }
}
