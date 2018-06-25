using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsManagement.Controllers;
using ContactsDBDataAccess;

namespace ContactsManagement.Tests.Controllers
{
    [TestClass]
    public class ContactsControllerTest
    {
        [TestMethod]
        public void GetAllContacts_ShouldReturnAllContacts()
        {
            var testContacts = GetTestContacts();
            var controller = new ContactsController();

            var result = controller.GetAllProducts() as List<Product>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }

        private List<Contact> GetTestContacts()
        {
            var testContacts = new List<Contact>();
            testContacts.Add(new Contact { Id = 1, Name = "Demo1", Price = 1 });
            testContacts.Add(new Contact { Id = 2, Name = "Demo2", Price = 3.75M });
            testContacts.Add(new Contact { Id = 3, Name = "Demo3", Price = 16.99M });
            testContacts.Add(new Contact { Id = 4, Name = "Demo4", Price = 11.00M });

            return testProducts;
        }
    }
}
