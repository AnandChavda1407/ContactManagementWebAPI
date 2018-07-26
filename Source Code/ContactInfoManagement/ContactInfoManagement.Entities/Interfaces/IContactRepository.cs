using ContactInfoManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoManagement.Entities.Interfaces
{
    public interface IContactRepository
    {
        void AddContact(ContactDetail contactDetail);

        void EditContact(ContactDetail contactDetail);

        void DeleteContact(int contactId);

        List<ContactDetail> GetContacts();

        ContactDetail FindContactById(int contactId);
    }
}
