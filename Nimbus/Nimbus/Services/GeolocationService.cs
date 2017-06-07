using Nimbus.Interfaces;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Services
{
    public class GeolocationService : IGeolocationService
    {
        private Position _Position { get; set; }
        private IGeolocator _Geolocator { get; }

        public GeolocationService()
        {
            _Position = new Position();
            _Geolocator = CrossGeolocator.Current;
            _Geolocator.DesiredAccuracy = 50;
        }

        /// <summary>
        ///     Recupera a localização do dispositivo.
        /// </summary>
        /// 
        /// <returns>
        ///     Objeto do tipo Position.
        /// </returns>
        public async Task<Position> GetLocationAsync()
        {
            try
            {
                _Position = await _Geolocator.GetPositionAsync(timeoutMilliseconds: 10000);

                return _Position;
            }
            catch (Exception)
            {
                return _Position;
            }
        }

    }
}
