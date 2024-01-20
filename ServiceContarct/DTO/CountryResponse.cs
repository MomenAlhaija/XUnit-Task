using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
namespace ServiceContarct.DTO
{
    public class CountryResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;   
            if(obj.GetType()!=typeof(CountryResponse)) return false; 
            CountryResponse country_To_Compare=(CountryResponse)obj; 
            return this.Id == country_To_Compare.Id &&
                              this.Name==country_To_Compare.Name;
        }
    }
    public static class CountryExtension
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            
            return new CountryResponse { Id = country.Id, Name = country.Name }; 
        }
    }
}
