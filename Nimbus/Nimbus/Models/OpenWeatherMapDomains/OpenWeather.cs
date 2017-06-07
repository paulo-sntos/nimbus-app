using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenWeatherMapDomain
{
    public class OpenWeather
    {
        /// <summary>
        ///     Cidade.
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public City City { get; set; }

        /// <summary>
        ///     Código (Parâmetro interno).
        /// </summary>
        [JsonProperty(PropertyName = "cod")]
        public string Code { get; set; }

        /// <summary>
        ///     Mensagem (Parâmetro interno).
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public float Message { get; set; }

        /// <summary>
        ///     Quantidade de linhas com Previsões retornadas pela chamada à API
        /// </summary>
        [JsonProperty(PropertyName = "cnt")]
        public int Count { get; set; }

        /// <summary>
        ///     Lista com as Previsões retornadas
        /// </summary>
        [JsonProperty(PropertyName = "list")]
        public List<Forecast> List { get; set; }
    }
}
