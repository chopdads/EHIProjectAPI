using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ContactAPI.Models;
using System.Net.Http;
using System.Web.Http;
using ContactAPI.Controllers;
using System.Web.Http.Routing;
using Moq;

namespace ContactAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        #region Positive Test Cases
        [TestMethod]
        public void GetContactList()
        {
            // Set up Prerequisites   
            var controller = new ContactController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.GetDetails();
            // Assert the result  
            Assert.IsTrue(response.StatusCode.ToString() == "OK");
        }
        [TestMethod]
        public void ContactGetById()
        {
            // Set up Prerequisites   
            var controller = new ContactController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.GetDetailsById(2);
            // Assert the result  
            Contact contact;
            Assert.IsTrue(response.TryGetContentValue<Contact>(out contact));
            Assert.AreEqual("James", contact.FirstName);
        }

        [TestMethod]
        public void ContactUpdate()
        {
            // Set up Prerequisites   
            var controller = new ContactController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var contactDetails = controller.GetDetailsById(1);
            Contact contact;
            contactDetails.TryGetContentValue<Contact>(out contact);
            var response = controller.Put(1, new Contact()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                Status = "Inactive"
            });
            // Assert the result  
            Assert.IsTrue(response.StatusCode.ToString() == "OK");
        }

        [TestMethod]
        public void ContactDelete()
        {
            // Set up Prerequisites   
            var controller = new ContactController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.Delete(11);
            // Assert the result  
            Assert.IsTrue(response.StatusCode.ToString() == "OK");
        }

        [TestMethod]
        public void ContactCreate()
        {
            // Set up Prerequisites   
            var controller = new ContactController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            Contact contact = new Contact()
            {
                FirstName = "ABC",
                LastName = "XYZ",
                Phone = "7418529630",
                Email = "abc@gmail.com",
                Status = "Active"
            };
            var response = controller.Post(contact);
            // Assert the result  
            Assert.IsTrue(response.StatusCode.ToString() == "Created");
        }

        #endregion

        #region Negative Test Cases
        [TestMethod]
        public void ContactGetById_Neg()
        {
            // Set up Prerequisites   
            var controller = new ContactController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.GetDetailsById(100);
            // Assert the result  
            Assert.IsTrue(response.StatusCode.ToString() == "NotFound");
        }

        [TestMethod]
        public void ContactUpdate_Neg()
        {
            // Set up Prerequisites   
            var controller = new ContactController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var contactDetails = controller.GetDetailsById(1);
            Contact contact;
            contactDetails.TryGetContentValue<Contact>(out contact);
            var response = controller.Put(1, new Contact()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                Status = "Something"
            });
            // Assert the result  
            Assert.IsTrue(response.StatusCode.ToString() == "BadRequest");
        }
        [TestMethod]
        public void ContactDelete_Neg()
        {
            // Set up Prerequisites   
            var controller = new ContactController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.Delete(18);
            // Assert the result  
            Assert.IsTrue(response.StatusCode.ToString() == "NotFound");
        }

        [TestMethod]
        public void ContactCreate_Neg()
        {
            // Set up Prerequisites   
            var controller = new ContactController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            Contact contact = new Contact()
            {
                FirstName = "ABC",
                LastName = "XYZ",
                Phone = "7418529630",
                Email = "abc@gmail.com",
                Status = "Something"
            };
            var response = controller.Post(contact);
            // Assert the result  
            Assert.IsTrue(response.StatusCode.ToString() == "BadRequest");
        }
        
        #endregion
    }
}
