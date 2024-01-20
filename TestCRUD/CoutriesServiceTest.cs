using Entites;
using Newtonsoft.Json.Linq;
using ServiceContarct;
using ServiceContarct.DTO;
using Services;
using Xunit;
namespace CRUDExample
{
    public class CoutriesServiceTest
    {
        private readonly ICountryService _countryService;
        public CoutriesServiceTest()
        {
            _countryService = new CountryService();
        }


        #region AddCountry
        /// <summary>
        /// Test if Pass Null  should throw Argument Null Exception 
        /// </summary>
        [Fact]
        public void AddCountry_NullCountry()
        {
            //Arrange
            CountryAddRequest country = null;
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countryService.AddCountry(country);
            });
        }
        /// <summary>
        /// check if Country Name is Null should throw Argument Null Exception 
        /// </summary>
        [Fact]
        public void AddCountry_CountryNameisNull()
        {
            //Arrange
            CountryAddRequest country = new CountryAddRequest() { Name = null };
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countryService.AddCountry(country);
            });
        }
        /// <summary>
        /// check if Country NAme is deplicate should throw Argument Exeption
        /// </summary>
        [Fact]

        public void AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddRequest country = new CountryAddRequest() { Name = "Irbid" };
            CountryAddRequest country2 = new CountryAddRequest() { Name = "Irbid" };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countryService.AddCountry(country);
                _countryService.AddCountry(country2);
            });
        }
        /// <summary>
        /// when Add Country should is found in the list countries
        /// </summary>
        [Fact]
        public void AddCountry_ProperCountryetailes()
        {
            //Arrange
            CountryAddRequest country = new CountryAddRequest() { Name = "USA" };
            //Act
            CountryResponse countryResponse = _countryService.AddCountry(country);
            //Assert
            List<CountryResponse> countries_from_GetAllCountries= _countryService.GetCountryList();
            Assert.True(countryResponse.Id != Guid.Empty);
            Assert.Contains(countryResponse, countries_from_GetAllCountries);
        }

        #endregion
        #region GetAllCountries
        [Fact]
        public void GetAllRegion_EmptyList()
        {
            //Act
            List<CountryResponse> actual_Country_Response_List=_countryService.GetCountryList();
            //Assert
            Assert.Empty(actual_Country_Response_List);
        }
        [Fact]
        public void GetAllRegion_AddFewCountries() {
            //Arrange
            List<CountryAddRequest> actual_Country_Request_List = new List<CountryAddRequest>()
            {
                new CountryAddRequest(){Name="Japan"},
                new CountryAddRequest(){Name="USA"},
                new CountryAddRequest(){Name="UKA"},
                new CountryAddRequest(){Name="Jordan"},
                new CountryAddRequest(){Name="Egypt"},

            };
            //Act
            List<CountryResponse> countries_list = new List<CountryResponse>();
            foreach(CountryAddRequest country in  actual_Country_Request_List)
            {
                countries_list.Add(_countryService.AddCountry(country));

            }
            List<CountryResponse> Actual_Response_Countries=
            _countryService.GetCountryList();

            foreach(CountryResponse country in countries_list)
            {
                Assert.Contains(country, Actual_Response_Countries);
            }
        }
        #endregion
        #region GetCountryById
        //so here the requirement is if you supply the country id as null value then it
        //should return the null so
        [Fact]
       
        public void GetCountryById_NullId()
        {
            //Arrange
            Guid? id = null;
            //Act
            CountryResponse? countryResponse= _countryService.GetCountryById(id);
            //Assert
            Assert.Null(countryResponse);
        }
        //if you supply the valid country id it should return the corresponding country
        [Fact]
        public void GetCountryById_ValiedCountryID() {
            //Arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest() { Name="Jordan"};
            CountryResponse countryResponse_from_Add=_countryService.AddCountry(countryAddRequest);
            //Act
            CountryResponse? countryResponse_from_GetById=_countryService.GetCountryById(countryResponse_from_Add.Id);
            //Assert
            Assert.Equal(countryResponse_from_Add, countryResponse_from_GetById);
          
        }
        #endregion

    }
}
