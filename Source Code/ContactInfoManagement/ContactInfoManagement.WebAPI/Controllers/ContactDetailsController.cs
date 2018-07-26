using ContactInfoManagement.DAL;
using ContactInfoManagement.Entities.Entities;
using ContactInfoManagement.Entities.Interfaces;
using ContactInfoManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace ContactInfoManagement.WebAPI.Controllers
{
    //[CustomExceptionFilter]
    public class ContactDetailsController : ApiController
    {
        private readonly IContactRepository repository;

        public ContactDetailsController() : this(new ContactInfoRepository())
        {

        }
        public ContactDetailsController(IContactRepository repository) => this.repository = repository;


        [HttpGet]
        [CustomExceptionFilter]
        [Route("~/api/GetAllContacts")]
        public List<ContactDetail> GetContacts()
        {
            return repository.GetContacts();
        }

        [ResponseType(typeof(ContactDetail))]
        [CustomExceptionFilter]
        [HttpGet]
        [Route("~/api/GetContactById/{id}")]
        public IHttpActionResult GetContactDetail(int id)
        {
            ContactDetail contactDetail = repository.FindContactById(id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            return Ok(contactDetail);
        }

        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [HttpPut]
        [Route("~/api/EditContact/{id}")]
        public IHttpActionResult PutContactDetail(int id, [FromBody]ContactDetail contactDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactDetail.ContactId)
            {
                return BadRequest();
            }

            try
            {
                repository.EditContact(contactDetail);
            }
            catch (System.Exception)
            {

                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [HttpPut]
        [Route("~/api/ActiveInActiveContact/{id}/{isActive}")]
        //To activate any user pass 1 in isactive and to inactive pass 0
        public IHttpActionResult ActiveInActiveContact(int id, int isActive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (isActive != 0 && isActive != 1)
                return BadRequest(ModelState);

            try
            {
                ContactDetail contactDetail = repository.FindContactById(id);
                if (contactDetail == null)
                {
                    return NotFound();
                }

                contactDetail.IsActive = System.Convert.ToBoolean(isActive);
                repository.EditContact(contactDetail);
            }
            catch (System.Exception)
            {

                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(ContactDetail))]
        [HttpPost]
        [CustomExceptionFilter]
        [Route("~/api/AddNewContact")]
        public IHttpActionResult PostContactDetail(ContactDetail contactDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                repository.AddContact(contactDetail);
                return CreatedAtRoute("~/api/ContactDetails", new { id = contactDetail.ContactId }, contactDetail);
            }
            catch(InvalidOperationException)
            {
                throw;
            }
            catch (System.Exception)
            {

                return NotFound();
            }

        }

        [ResponseType(typeof(ContactDetail))]
        [CustomExceptionFilter]
        [Route("~/api/DeleteContact/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteContactDetail(int id)
        {
            ContactDetail contactDetail = repository.FindContactById(id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            repository.DeleteContact(id);
            return Ok(contactDetail);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


    }
}