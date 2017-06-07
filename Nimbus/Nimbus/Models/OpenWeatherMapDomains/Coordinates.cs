using Newtonsoft.Json;

namespace OpenWeatherMapDomain
{
    public class Coordinates
    {
        /// <summary>
        ///     Longitude.
        /// </summary>
        [JsonProperty(PropertyName = "lon")]
        public float Longitude { get; set; }

        /// <summary>
        ///     Latitude.
        /// </summary>
        [JsonProperty(PropertyName = "lat")]
        public float Latitude { get; set; }
    }
}
