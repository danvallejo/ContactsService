using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldService.Models
{
    public class Contact
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public Phone[] Phones { get; set; }

        public HelloWorldRepository.Contact ConvertToRepository()
        {
            var phones = new List<HelloWorldRepository.Phone>();

            foreach (var phone in Phones)
            {
                var repositoryPhone = new HelloWorldRepository.Phone
                {
                    Number = phone.Number,
                    PhoneType = (HelloWorldRepository.PhoneType)
                                Enum.Parse(typeof(HelloWorldRepository.PhoneType),
                                phone.PhoneType.ToString(), true),
                };

                phones.Add(repositoryPhone);
            }

            var contact = new HelloWorldRepository.Contact
            {
                ID = ID,
                Name = Name,
                DateAdded = DateAdded,
                Phones = phones.ToArray(),
            };

            return contact;
        }
    }

    public class Phone
    {
        public string Number { get; set; }

        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PhoneType PhoneType { get; set; }
    }

    public enum PhoneType
    {
        Home,
        Cell,
    }
}