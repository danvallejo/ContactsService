using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldRepository
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public Phone[] Phones { get; set; }
    }

    public class Phone
    {
        public string Number { get; set; }
        public PhoneType PhoneType { get; set; }
    }

    public enum PhoneType
    {
        Home,
        Cell,
    }
}
