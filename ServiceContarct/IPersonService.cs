using ServiceContarct.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceContarct.DTO;
namespace ServiceContarct
{
    public interface IPersonService
    {
       PersonResponce AddPerson(PersonAddrequest? personAddRequest);
       List<PersonResponce> GetAllPersons();
    }
}
