using ContactInfoManagement.Entities.Entities;
using System.Data.Entity;

namespace ContactInfoManagement.DAL
{
    public class ContactInfoDBInitialize : DropCreateDatabaseIfModelChanges<ContactInfoContext>
    {

        protected override void Seed(ContactInfoContext context)
        {
            context.Contacts.Add
             (
                 new ContactDetail
                 {
                     ContactId = 1,
                     FirstName = "Virat",
                     LastName = "Kohli",
                     EmailId = "Virat_Kohli@gmail.com",
                     PhoneNo = "1122334455",
                     IsActive = true
                 });

            context.Contacts.Add
             (
                 new ContactDetail
                 {
                     ContactId = 2,
                     FirstName = "Mahendra Singh",
                     LastName = "Dhoni",
                     EmailId = "msd@gmail.com",
                     PhoneNo = "1122334466",
                     IsActive = true
                 });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
