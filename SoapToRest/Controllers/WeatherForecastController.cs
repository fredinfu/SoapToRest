using AutoMapper;
using CalculatorSoapReference;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoapToRest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoapToRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("AddCalculator")]
        public object AddCalculator(int a, int b)
        {
            var soapClient = new ServiceReference1.CalculatorSoapClient(new ServiceReference1.CalculatorSoapClient.EndpointConfiguration());

            var response = soapClient.AddAsync(a, b).Result;

            return response;
        }

        [HttpGet("CountriesGroupedByContinent")]
        public object CountriesGroupedByContinent()
        {
            var soapClient = new CountryInfoClientReference.CountryInfoServiceSoapTypeClient(new CountryInfoClientReference.CountryInfoServiceSoapTypeClient.EndpointConfiguration());

            var response = new CountryCodeAndNameGroupedByContinentResponseBody
            {
                ListOfCountryNamesGroupedByContinentResult = soapClient.ListOfCountryNamesGroupedByContinentAsync().Result.Body.ListOfCountryNamesGroupedByContinentResult
            };
            var dto = _mapper.Map<CountryCodeAndNameGroupedByContinentBodyDto>(response);
            return response;
        }
    }
}
