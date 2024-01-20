using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
namespace ServiceContarct.DTO
{
    /// <summary>
    /// Dto Country Add new Country 
    /// </summary>
    public class CountryAddRequest
    {
        public string? Name { get; set; }
        public Country ToCountry() { return new Country { Name = Name };}
    }
}
