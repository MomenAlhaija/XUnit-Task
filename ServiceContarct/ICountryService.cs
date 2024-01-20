using Entites;
using ServiceContarct.DTO;
namespace ServiceContarct
{
    public interface ICountryService
    {
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);
        /// <summary>
        /// Return all Countries
        /// </summary>
        /// <returns></returns>
        List<CountryResponse> GetCountryList();

        /// <summary>
        /// Get Country By Country  ID
        /// </summary>
        /// <param name="countryId">countryId (Guid) to search</param>
        /// <returns></returns>
        CountryResponse? GetCountryById(Guid? countryId);
    }
}