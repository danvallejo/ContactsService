using Contacts.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HelloWorldClient
{
      public class Contact
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("DateAdded")]
        public DateTime DateAdded { get; set; }
        [JsonProperty("Phones")]
        public Phone[] Phones { get; set; }
    }

    public class Phone
    {
        [JsonProperty("Number")]
        public string Number { get; set; }
        [JsonProperty("PhoneType")]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PhoneType PhoneType { get; set; }
    }

    public enum PhoneType
    {
        Nil,
        Home,
        Mobile,
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new Contacts.Linq.ContactsDataContext("Server=(local);Database=Contacts;Trusted_Connection=True;");

            context.Connection.Open();

            var contacts = from row in context.Contacts1 select row;

            var contacts2 = context.Contacts1.Select(row => row.ContactId).ToArray();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/helloworldservice/api/");
            var result = client.GetAsync("contacts").Result;
            var json = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(json);
            var obj = JsonConvert.DeserializeObject<List<Contact>>(json);
            Console.ReadLine();
        }
    }
}

