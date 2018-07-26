using ContactInfoManagement.Entities.Entities;
using System.Data.Entity;

namespace ContactInfoManagement.DAL
{
    public class ContactInfoContext : DbContext
    {
        public ContactInfoContext() : base("name=DBConn")
        {
            Database.SetInitializer<ContactInfoContext>(new ContactInfoDBInitialize());

        }

        public DbSet<ContactDetail> Contacts { get; set; }
    }
}
