using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapDomain
{
    public class Weather
    {
        /// <summary>
        ///     Id da Condição do Clima.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        ///     Tipo de Clima.
        /// </summary>
        [JsonProperty(PropertyName = "main")]
        public string Main { get; set; }

        /// <summary>
        ///     Descrição do Clima.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        ///     Ícone do tipo de Clima.
        /// </summary>
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
    }
}
