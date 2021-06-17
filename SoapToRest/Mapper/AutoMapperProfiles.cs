
using SoapToRest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SoapToRest.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SoapToRest.Dtos.CountryCodeAndNameGroupedByContinentResponseBody, CountryCodeAndNameGroupedByContinentBodyDto>();
        }
        
    }
}
