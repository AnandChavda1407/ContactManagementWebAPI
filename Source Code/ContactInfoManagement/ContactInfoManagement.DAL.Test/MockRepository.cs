using ContactInfoManagement.Entities.Entities;
using ContactInfoManagement.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoManagement.DAL.Test
{
    public class MockRepository : IContactRepository
    {
        List<ContactDetail> contacts;

        public bool FailGet { get; set; }
        public MockRepository()
        {
            contacts = new List<ContactDetail>() {
            new ContactDetail(){ContactId=1, FirstName="F1", PhoneNo="1992637281", LastName="L1",EmailId="f1@f1.com",IsActive=true},
            new ContactDetail(){ContactId=2, FirstName="F2", PhoneNo="9172735171", LastName="L2",EmailId="f2@f2.com",IsActive=true},
            new ContactDetail(){ContactId=3, FirstName="F3", PhoneNo="8361910353", LastName="L3",EmailId="f3@f3.com",IsActive=true},
            new ContactDetail(){ContactId=4, FirstName="F4", PhoneNo="7801274518", LastName="L4",EmailId="f4@f4.com",IsActive=true}
        };
        }
        public void AddContact(ContactDetail contactDetail)
        {
            if (FailGet)
            {
                throw new InvalidOperationException();
            }
            contacts.Add(contactDetail);
        }

        public void DeleteContact(int contactId)
        {
            if (FailGet)
            {
                throw new InvalidOperationException();
            }
            ContactDetail contactDetail = contacts.Find(x => x.ContactId == contactId);
            contacts.Remove(contactDetail);
        }

        public void EditContact(ContactDetail contactDetail)
        {
            if (FailGet)
            {
                throw new InvalidOperationException();
            }
            ContactDetail contactDetail2 = contacts.Where(i => i.FirstName == contactDetail.FirstName).First();
            var index = contacts.IndexOf(contactDetail2);

            if (index != -1)
                contacts[index] = contactDetail;
        }

        public ContactDetail FindContactById(int contactId)
        {
            if (FailGet)
            {
                throw new InvalidOperationException();
            }
            var data = (from contact in contacts
                        where contact.ContactId == contactId
                        select contact).FirstOrDefault();
            return data;
        }

        public List<ContactDetail> GetContacts()
        {
            if (FailGet)
            {
                throw new InvalidOperationException();
            }
            return contacts;
        }
    }
}
