using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoapToRest.Dtos
{
    public class CountryCodeAndNameGroupedByContinentResponseBody
    {
        public CountryInfoClientReference.tCountryCodeAndNameGroupedByContinent[] ListOfCountryNamesGroupedByContinentResult { get; set; }
    }
    public class CountryCodeAndNameGroupedByContinentBodyDto
    {
        public CountryCodeAndNameGroupedByContinentDto [] ListOfCountryNamesGroupedByContinentResult { get; set; }
    }
    public class CountryCodeAndNameGroupedByContinentDto
    {
        public ContinentDto Continent{ get; set; }
        public CountryCodeAndNameDto[] CountryCodeAndNames{ get; set; }
    }

    public class ContinentDto
    {
        public string sCode { get; set; }
        public string sName { get; set; }
    }

    public class CountryCodeAndNameDto
    {
        public string sName { get; set; }
        public string sISOCode { get; set; }
    }
}
