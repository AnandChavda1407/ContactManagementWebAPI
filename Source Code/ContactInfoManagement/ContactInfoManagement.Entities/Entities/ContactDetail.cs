using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoManagement.Entities.Entities
{
    public class ContactDetail
    {
        public ContactDetail()
        {

        }

        private int contactId;
        private string firstName;
        private string lastName;
        private string emailId;
        private string phoneNo;
        private bool isActive;

        [Key]
        public int ContactId { get => contactId; set => contactId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string EmailId { get => emailId; set => emailId = value; }
        public string PhoneNo { get => phoneNo; set => phoneNo = value; }

        //true for active and false for inactive
        public bool IsActive { get => isActive; set => isActive = value; }
    }
}
