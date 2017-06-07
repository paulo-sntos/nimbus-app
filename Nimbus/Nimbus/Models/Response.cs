using OpenWeatherMapDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Models
{
    public class Response
    {

        public OpenWeather OpenWeather { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

    }
}
