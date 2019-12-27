using StackExchange.Redis;
using System.Threading.Tasks;
using MR = MediPlus.Domain.IRepositories.BaseRepository;
namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {
        public bool GeoAdd(string key, double longitude, double latitude, string geoName) => Do(db => db.GeoAdd(AddPreFixKey(key), longitude, latitude, geoName));
        public Task<bool> GeoAddAsync(string key, double longitude, double latitude, string geoName) => Do(db => db.GeoAddAsync(AddPreFixKey(key), longitude, latitude, geoName)); 
        public bool GeoRemove(string key, string geoName) => Do(db => db.GeoRemove(key, geoName));
        public Task<bool> GeoRemoveAsync(string key, string geoName) => Do(db => db.GeoRemoveAsync(key, geoName));
        public double? GeoDist(string key, string geoName1, string geoName2) => Do(db => db.GeoDistance(AddPreFixKey(key), geoName1, geoName2));
        public Task<double?> GeoDistAsync(string key, string geoName1, string geoName2) => Do(db => db.GeoDistanceAsync(AddPreFixKey(key), geoName1, geoName2));
        public MR.GeoPosition? GeoPos(string key, string geoName)
        {
            GeoPosition? geo = Do(db => db.GeoPosition(AddPreFixKey(key), geoName));
            if (geo.HasValue)
            {
                return new MR.GeoPosition() { Longitude = geo.Value.Longitude, Latitude = geo.Value.Latitude };
            }
            return null;
        }
        public async Task<MR.GeoPosition?> GeoPosAsync(string key, string geoName)
        {
            GeoPosition? geo = await Do(db => db.GeoPositionAsync(AddPreFixKey(key), geoName));
            if (geo.HasValue)
            {
                return new MR.GeoPosition() { Longitude = geo.Value.Longitude, Latitude = geo.Value.Latitude };
            }
            return null;
        }
        public MR.GeoRadiusResult[] GeoRadius(string key, double longitude, double latitude, double radius, int count = -1, bool asc = true) => Do(db => db.GeoRadius(AddPreFixKey(key), longitude, latitude, radius, GeoUnit.Meters, count, asc ? Order.Ascending : Order.Descending));
        public MR.GeoRadiusResult[] GeoRadius(string key, string geoName, double radius, int count = -1, bool asc = true) => Do(db => db.GeoRadius(AddPreFixKey(key), geoName, radius, GeoUnit.Meters, count, asc ? Order.Ascending : Order.Descending));
        public Task<MR.GeoRadiusResult[]> GeoRadiusAsync(string key, double longitude, double latitude, double radius, int count = -1, bool asc = true) => Do(db => db.GeoRadiusAsync(AddPreFixKey(key), longitude, latitude, radius, GeoUnit.Meters, count, asc ? Order.Ascending : Order.Descending));
        public Task<MR.GeoRadiusResult[]> GeoRadiusAsync(string key, string geoName, double radius, int count = -1, bool asc = true) => Do(db => db.GeoRadiusAsync(AddPreFixKey(key), geoName, radius, GeoUnit.Meters, count, asc ? Order.Ascending : Order.Descending));
    }
}
