using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using HelloWorldRepository;
using HelloWorldService.Models;

namespace HelloWorldService.Controllers
{
    public class ContactsController : ApiController
    {
        private ContactsRepository contactsRepository = new ContactsRepository();

        // GET api/contacts 
        public IEnumerable<Models.Contact> Get()
        {
            return contactsRepository.Contacts.Select(t => new Models.Contact
            {
                ID = t.ID,
                Name = t.Name,
                DateAdded = t.DateAdded,
            });
        }

        // GET api/contacts/5
        public Models.Contact Get(int id)
        {
            var contact = contactsRepository.Get(id);

            if (contact == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return new Models.Contact
            {
                ID = contact.ID,
                Name = contact.Name,
                DateAdded = contact.DateAdded,
            };
        }

        // POST api/contacts
        public void Post([FromBody]Models.Contact contact)
        {
            contactsRepository.Add(new HelloWorldRepository.Contact
            {
                ID = contact.ID,
                Name = contact.Name,
                DateAdded = contact.DateAdded,
            });
        }

        // PUT api/contacts/5
        public void Put(int id, [FromBody]Models.Contact value)
        {
        }

        // DELETE api/contacts/5
        public void Delete(int id)
        {
            contactsRepository.Delete(id);
        }
    }
}
