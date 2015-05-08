using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using HelloWorldRepository;

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
        public Contact Get(int id)
        {
            var contact =  contacts.FirstOrDefault(t => t.ID == id);

            if (contact == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return contact;
        }

        // POST api/contacts
        public void Post([FromBody]Contact value)
        {
            value.ID = nextId++;
            contacts.Add(value);
            value.DateAdded = DateTime.Now;
        }

        // PUT api/contacts/5
        public void Put(int id, [FromBody]Contact value)
        {
        }

        // DELETE api/contacts/5
        public void Delete(int id)
        {
        }
    }
}
