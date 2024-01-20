using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
using ServiceContarct.Enums;
namespace ServiceContarct.DTO
{
    public class PersonAddrequest
    {
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateofBirth { get; set; }
        public Gender? Gender { get; set; }
        public Guid? CountryId { get; set; }
        public string? Address { get; set; }
        public bool RecieveNesLetters { get; set; }

        public Person ToPerson()
        {
            return new Person
            {
                PersonName = PersonName,
                Email = Email,
                DateofBirth = DateofBirth,
                Gender = Gender.ToString(),
                CountryId = CountryId,
                Address = Address,
                RecieveNesLetters = RecieveNesLetters
            };
        }
    }
}
