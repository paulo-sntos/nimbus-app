using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapDomain
{
    public class Forecast
    {
        /// <summary>
        ///     Data e Hora da Previsão (Padrão UTC-0).
        /// </summary>
        [JsonProperty(PropertyName = "dt")]
        public DateTime DateTime { get; set; }

        /// <summary>
        ///     Temperatura.
        /// </summary>
        [JsonProperty(PropertyName = "temp")]
        public Temperature Temperature { get; set; }

        /// <summary>
        ///     Pressão do Ar.
        /// </summary>
        [JsonProperty(PropertyName = "pressure")]
        public float Pressure { get; set; }

        /// <summary>
        ///     Umidade do Ar.
        /// </summary>
        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }

        /// <summary>
        ///     Tipo de Clima.
        /// </summary>
        [JsonProperty(PropertyName = "weather")]
        public List<Weather> Weather { get; set; }

        /// <summary>
        ///     Velocidade do vento (metros/segundos).
        /// </summary>
        [JsonProperty(PropertyName = "speed")]
        public float Wind { get; set; }

        /// <summary>
        ///     Direção do vento.
        /// </summary>
        [JsonProperty(PropertyName = "deg")]
        public float Degree { get; set; }

        /// <summary>
        ///     Volume de chuva nas últimas 3 horas.
        /// </summary>
        [JsonProperty(PropertyName = "rain")]
        public float Rain { get; set; }
    }
}
