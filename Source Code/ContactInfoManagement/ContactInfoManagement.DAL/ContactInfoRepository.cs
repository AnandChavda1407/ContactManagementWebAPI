using ContactInfoManagement.Entities.Entities;
using ContactInfoManagement.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactInfoManagement.DAL
{
    public class ContactInfoRepository : IContactRepository
    {

        static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// This method is used to Add contacts in the database
        /// </summary>
        /// <param name="contactDetail">contacts to add</param>
        public void AddContact(ContactDetail contactDetail)
        {
            try
            {
                using (var context = new ContactInfoContext())
                {
                    context.Contacts.Add(contactDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error in AddContact.", ex);
                throw;
            }
        }


        /// <summary>
        /// This method is used to delete any contact from database
        /// </summary>
        /// <param name="contactId">contactid by which you can delete record</param>
        public void DeleteContact(int contactId)
        {
            try
            {
                using (var context = new ContactInfoContext())
                {
                    ContactDetail contactDetail = context.Contacts.Find(contactId);
                    context.Contacts.Remove(contactDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                log.Error("Error in DeleteContact.", ex);
                throw;
            }
        }

        /// <summary>
        /// This method is used to update contact in database
        /// </summary>
        /// <param name="contactDetail"></param>
        public void EditContact(ContactDetail contactDetail)
        {
            try
            {
                using (var context = new ContactInfoContext())
                {
                    context.Entry(contactDetail).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                log.Error("Error in EditContact.", ex);
                throw;
            }
        }

        /// <summary>
        /// This method is used to find any contact by contactid
        /// </summary>
        /// <param name="contactId">contactid to find contact details</param>
        /// <returns>contact details</returns>
        public ContactDetail FindContactById(int contactId)
        {
            try
            {
                using (var context = new ContactInfoContext())
                {
                    var data = (from contact in context.Contacts
                                where contact.ContactId == contactId
                                select contact).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error in FindContactById.", ex);
                throw;
            }
        }

        /// <summary>
        /// This method is used to get all the contact details from the database
        /// </summary>
        /// <returns>List of contacts</returns>
        public List<ContactDetail> GetContacts()
        {
            try
            {
                using (var context = new ContactInfoContext())
                {
                    return context.Contacts.ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error in GetContacts.", ex);
                throw;
            }

        }
    }
}
