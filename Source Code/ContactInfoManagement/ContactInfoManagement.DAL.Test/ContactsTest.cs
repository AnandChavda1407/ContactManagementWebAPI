using ContactInfoManagement.Entities.Entities;
using ContactInfoManagement.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ContactInfoManagement.DAL.Test
{
    [TestClass]
    public class ContactsTest
    {

        MockRepository repository;
        ContactDetailsController contactsApi;

        [TestInitialize]
        public void InitializeForTests()
        {
            repository = new MockRepository();
            contactsApi = new ContactDetailsController(repository);
        }


        [TestMethod]
        public void GetContacts()
        {

            int count= 0;
            var contacts = contactsApi.GetContacts();

            foreach (var item in contacts)
            {
                count++;
            }
            Assert.AreEqual(count, 4);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetContacts_Throw_Exception()
        {
            repository.FailGet = true;
            var contacts = contactsApi.GetContacts();
        }

        [TestMethod]
        public void AddContacts()
        {
            ContactDetail cd = new ContactDetail() { ContactId = 5, FirstName = "F5", PhoneNo = "1992637281", LastName = "L5", EmailId = "f5@f5.com", IsActive = true };
            int count = 0;
            contactsApi.PostContactDetail(cd);
            var contacts = contactsApi.GetContacts();
            foreach (var item in contacts)
            {
                count++;
            }
            Assert.AreEqual(count, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddContacts_Throw_Exception()
        {
            ContactDetail cd = new ContactDetail() { ContactId = 5, FirstName = "F5", PhoneNo = "1992637281", LastName = "L5", EmailId = "f5@f5.com", IsActive = true };
            repository.FailGet = true;
            var contacts = contactsApi.PostContactDetail(cd);
        }

        [TestMethod]
        public void DeleteContacts()
        {
            ContactDetail cd = new ContactDetail() { ContactId = 5, FirstName = "F5", PhoneNo = "1992637281", LastName = "L5", EmailId = "f5@f5.com", IsActive = true };
            int count = 0;
            contactsApi.DeleteContactDetail(3);
            var contacts = contactsApi.GetContacts();
            foreach (var item in contacts)
            {
                count++;
            }
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteContacts_Throw_Exception()
        {
            repository.FailGet = true;
            var contacts = contactsApi.DeleteContactDetail(3);
        }
    }
}
