using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContarct.DTO
{
    public  class PersonResponce
    {
        public Guid PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryId { get; set; }
        public string? Address { get; set; }
        public bool RecieveNesLetters { get; set; }
        public Double? Age { get; set; }    

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(PersonResponce)) return false;
            PersonResponce Person_To_Compare = (PersonResponce)obj;
            return PersonId == Person_To_Compare.PersonId &&
                   PersonName == Person_To_Compare.PersonName &&
                   Email == Person_To_Compare.Email &&
                   DateofBirth == Person_To_Compare.DateofBirth &&
                   Gender == Person_To_Compare.Gender &&
                   CountryId == Person_To_Compare.CountryId &&
                   Address == Person_To_Compare.Address &&
                   RecieveNesLetters == Person_To_Compare.RecieveNesLetters;



        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class PersonExtension
    {
        public static PersonResponce ToPersonResponse(this Person person)
        {
            return new PersonResponce()
            {
                PersonId = person.PersonId,
                PersonName = person.PersonName,
                Email = person.Email,
                DateofBirth = person.DateofBirth,
                Gender = person.Gender,
                CountryId = person.CountryId,
                Address = person.Address,
                RecieveNesLetters = person.RecieveNesLetters,
                Age = (person.DateofBirth != null) ? Math.Round((DateTime.Now - person.DateofBirth.Value).TotalDays / 365.25) : null
            };

            
        }
    }
}
