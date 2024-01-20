using ServiceContarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Services;
using Xunit.Sdk;
using Newtonsoft.Json.Linq;
using ServiceContarct.DTO;
using Entites;
using ServiceContarct.Enums;
namespace TestCRUD
{
    public class PersonServiceTest
    {
        private readonly IPersonService _personService;
        public PersonServiceTest()
        {
            _personService = new PersonService();
        }
        #region AddPerson
        //when you supply a null value as person add request it should not
        //insert the person but it should throw argument null exception because
        //whenever the value of an argument is null unexpectedly or unwantedly
        [Fact]
        public void AddPerson_NullPerson()
        {
            //Arrange
            PersonAddrequest personAddrequest = null;
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                _personService.AddPerson(personAddrequest); 
            });
        }
        //that is when you supply a person name as null value again it should
        //throw another exception that is argument exception
        [Fact]
        public void AddPerson_PersonNameNull()
        {
            //Arrange
            PersonAddrequest personAddrequest = new PersonAddrequest()
            {
                PersonName=null
            };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _personService.AddPerson(personAddrequest);
            });
        }
        //when we supply proper person details it should insert the person into the
        //person's list and it should return an object of the person response which
        //includes with the newly generated person id
        [Fact]
        public void AddPerson_ProperPersonDetailes()
        {
            //Arrange
            PersonAddrequest personAddrequest = new PersonAddrequest()
            {
                PersonName = "Momen",
                Email = "haija@gmail.com",
                Address = "sampleAddress",
                CountryId = Guid.NewGuid(),
                Gender=Gender.Male,
                DateofBirth=DateTime.Parse("20001-01-01"),
                RecieveNesLetters=true

            };
            //ACt
           PersonResponce person_responce_from_add=_personService.AddPerson(personAddrequest);
            List<PersonResponce> Person_List=_personService.GetAllPersons();
            //Assert
            Assert.True(person_responce_from_add.PersonId != Guid.Empty);
            Assert.Contains(person_responce_from_add, Person_List);
        }
        #endregion
    }
}
