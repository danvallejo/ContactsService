using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldRepository
{
    public class ContactsRepository
    {
        private Contacts.Linq.ContactsDataContext context;

        public ContactsRepository()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ContactsConnection"].ConnectionString;
            context = new Contacts.Linq.ContactsDataContext(connectionString);
            context.Connection.Open();
        }

        public IEnumerable<Contact> Contacts
        {
            get
            {
                var contacts = from row in context.Contacts1
                               select new Contact
                               {
                                   ID = row.ContactId,
                                   DateAdded = row.ContactDateAdded,
                                   Name = row.ContactName,
                               };

                return contacts;
            }
        }

        public Contact Add(Contact contact)
        {
            var linqContact = new Contacts.Linq.Contact
            {
                ContactName = contact.Name,
            };

            context.Contacts1.InsertOnSubmit(linqContact);

            context.SubmitChanges();

            return new Contact
            {
                ID = linqContact.ContactId,
                Name = linqContact.ContactName,
                DateAdded = linqContact.ContactDateAdded,
            };
        }

        public Contact Get(int id)
        {
            var contact = context.Contacts1.SingleOrDefault(t => t.ContactId == id);

            if (contact == null)
            {
                return null;
            }

            return new Contact
            {
                ID = contact.ContactId,
                Name = contact.ContactName,
                DateAdded = contact.ContactDateAdded,
            };
        }

        public Contact Delete(int id)
        {
            var contact = context.Contacts1.SingleOrDefault(t => t.ContactId == id);

            if (contact == null)
            {
                return null;
            }

            context.Contacts1.DeleteOnSubmit(contact);
            context.SubmitChanges();

            return new Contact
            {
                ID = contact.ContactId,
                Name = contact.ContactName,
                DateAdded = contact.ContactDateAdded,
            };
        }
    }
}
