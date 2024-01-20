using Entites;
using ServiceContarct;
using ServiceContarct.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _persons;
        public PersonService()
        {
            _persons = new List<Person>();
        }
        public PersonResponce AddPerson(PersonAddrequest? personAddRequest)
        {
          if(personAddRequest == null)  throw new ArgumentNullException(nameof(personAddRequest));
          if (personAddRequest.PersonName == null) throw new ArgumentException(nameof(personAddRequest.PersonName));

          Person person= personAddRequest.ToPerson();
            person.PersonId=Guid.NewGuid();
            _persons.Add(person);
            return person.ToPersonResponse();
        }

        public List<PersonResponce> GetAllPersons()
        {
            throw new NotImplementedException();
        }
    }
}
