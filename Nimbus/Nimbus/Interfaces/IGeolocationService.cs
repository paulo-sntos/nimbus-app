using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Interfaces
{
    public interface IGeolocationService
    {
        /// <summary>
        ///     Recupera a localização do dispositivo.
        /// </summary>
        ///
        /// <returns>
        ///     Objeto do tipo Position.
        /// </returns>
        Task<Position> GetLocationAsync();
    }
}
