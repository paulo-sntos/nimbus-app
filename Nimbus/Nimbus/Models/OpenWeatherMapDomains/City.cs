using Newtonsoft.Json;
using System;

namespace OpenWeatherMapDomain
{
    public class City
    {
        /// <summary>
        ///     Id da Cidade.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        ///     Nome da Cidade.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Coordenadas da Cidade (Latitude e Longitude).
        /// </summary>
        [JsonProperty(PropertyName = "coord")]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        ///     País ao qual a cidade pertence (Padrão de Formato ISO3166).
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public String Country { get; set; }

        /// <summary>
        ///     População da Cidade.
        /// </summary>
        [JsonProperty(PropertyName = "population")]
        public long Population { get; set; }

    }
}
