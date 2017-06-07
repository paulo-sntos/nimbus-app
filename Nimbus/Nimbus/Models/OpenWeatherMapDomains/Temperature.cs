using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapDomain
{
    public class Temperature
    {
        /// <summary>
        ///     Temperatura durante o dia.
        /// </summary>
        [JsonProperty(PropertyName = "day")]
        public float Day { get; set; }

        /// <summary>
        ///     Temperatura mínima.
        /// </summary>
        [JsonProperty(PropertyName = "min")]
        public float Minimum { get; set; }

        /// <summary>
        ///     Temperatura máxima.
        /// </summary>
        [JsonProperty(PropertyName = "max")]
        public float Maximum { get; set; }

        /// <summary>
        ///     Temperatura durante a noite.
        /// </summary>
        [JsonProperty(PropertyName = "night")]
        public float Night { get; set; }

        /// <summary>
        ///     Temperatura durante a tarde.
        /// </summary>
        [JsonProperty(PropertyName = "eve")]
        public float Evening { get; set; }

        /// <summary>
        ///     Temperatura durante a manhã.
        /// </summary>
        [JsonProperty(PropertyName = "morn")]
        public float Morning { get; set; }
    }
}
