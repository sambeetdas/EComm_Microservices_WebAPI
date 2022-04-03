using DataAccess.IRepository;
using Model;
using ServiceManager.IManager;

namespace ServiceManager.Manager
{
    public class GeoConfig : IGeoConfig
    {
        private readonly IGeoRepository _geoRepository;
        public GeoConfig(IGeoRepository geoRepository)
        {
            this._geoRepository = geoRepository;
        }

        public GeoLocationModel GetGeolocation()
        {
            dynamic result = _geoRepository.GetGeoLocation();
            return result;
        }


    }
}
