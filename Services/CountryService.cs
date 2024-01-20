using Entites;
using ServiceContarct;
using ServiceContarct.DTO;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Services
{
    public class CountryService : ICountryService
    {
        private readonly List<Country> _countries;

        public CountryService()
        {
            _countries = new List<Country>();
        }
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            //check the country is null or Country Name is Null
            if (countryAddRequest == null || countryAddRequest.Name==null)
                throw new  ArgumentNullException(nameof(countryAddRequest));
            //Convert Object from CountryAddRequest to object from Country
            Country country = countryAddRequest.ToCountry();
            //check the Country already found in the List
            if (_countries.Where(Cn=>Cn.Name==countryAddRequest.Name).Count()>0)
                throw new ArgumentException(nameof(country));
           //else pass add country
            country.Id=Guid.NewGuid();   
            _countries.Add(country);
            return country.ToCountryResponse();
        }

        public CountryResponse? GetCountryById(Guid? countryId)
        {
            if(countryId == null) return null;
            Country? country= _countries.FirstOrDefault(c => c.Id == countryId);
            return country.ToCountryResponse() ?? null;
        }

        public List<CountryResponse> GetCountryList()
        {
         return _countries.Select(country => country.ToCountryResponse()).ToList();
        }
    }
}