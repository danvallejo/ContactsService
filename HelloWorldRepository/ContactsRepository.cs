using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldRepository
{
    public class ContactsRepository
    {
        private static int nextId = 100;
        private static List<Contact> contacts = new List<Contact>();

        public IEnumerable<Contact> Contacts
        {
            get
            {
                return contacts;
            }
        }

        public Addcontact
    }
}
