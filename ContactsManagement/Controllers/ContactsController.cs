using ContactsDBDataAccess;
using ContactsDBDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactsManagement.Controllers
{
    public class ContactsController : ApiController
    {
        private IEntityBaseRepository<Contact> _contactRepository;

        public ContactsController(IEntityBaseRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET api/values
        public IList<Contact> Get()
        {
            return _contactRepository.GetAll();
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                //Verify if the resource exists.
                Contact contact = _contactRepository.Get(id);

                if (contact == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, contact);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Contact contact)
        {
            try
            {
                //Checked if the model is valid.
                if (ModelState.IsValid)
                {
                    _contactRepository.Insert(contact);

                    var message = Request.CreateResponse(HttpStatusCode.Created, contact.ContactID);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + contact.ContactID.ToString());

                    return message;
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Contact contact)
        {
            try
            {
                if(_contactRepository.Update(contact))
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record with Contact ID = " + id.ToString() + " was not found to update.");                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (_contactRepository.Delete(id))
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record with ID = " + id.ToString() + " was not found to delete.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
