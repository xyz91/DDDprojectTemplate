using StackExchange.Redis;
using System.Threading.Tasks;
using MR = MediPlus.Domain.IRepositories.BaseRepository;
namespace MeidPlus.Repository.RedisRepository
{
    public partial class RedisBaseRepository
    {
        /// <summary>
        /// 添加一个位置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="geoName">名字</param>
        /// <returns></returns>
        public bool GeoAdd(string key, double longitude, double latitude, string geoName) => Do(db => db.GeoAdd(AddPreFixKey(key), longitude, latitude, geoName));
        /// <summary>
        /// 添加一个位置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="geoName">名字</param>
        /// <returns></returns>
        public Task<bool> GeoAddAsync(string key, double longitude, double latitude, string geoName) => Do(db => db.GeoAddAsync(AddPreFixKey(key), longitude, latitude, geoName));
        /// <summary>
        /// 删除位置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="geoName"></param>
        /// <returns></returns>
        public bool GeoRemove(string key, string geoName) => Do(db => db.GeoRemove(key, geoName));
        /// <summary>
        /// 删除位置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="geoName"></param>
        /// <returns></returns>
        public Task<bool> GeoRemoveAsync(string key, string geoName) => Do(db => db.GeoRemoveAsync(key, geoName));
        /// <summary>
        /// 返回两个地址的距离(m)
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName1">地址1</param>
        /// <param name="geoName2">地址2</param>
        /// <returns></returns>
        public double? GeoDist(string key, string geoName1, string geoName2) => Do(db => db.GeoDistance(AddPreFixKey(key), geoName1, geoName2));
        /// <summary>
        /// 返回两个地址的距离(m)
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName1">地址1</param>
        /// <param name="geoName2">地址2</param>
        /// <returns></returns>
        public Task<double?> GeoDistAsync(string key, string geoName1, string geoName2) => Do(db => db.GeoDistanceAsync(AddPreFixKey(key), geoName1, geoName2));
        /// <summary>
        /// 获取位置
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName">地址</param>
        /// <returns></returns>
        public MR.GeoPosition? GeoPos(string key, string geoName)
        {
            GeoPosition? geo = Do(db => db.GeoPosition(AddPreFixKey(key), geoName));
            if (geo.HasValue)
            {
                return new MR.GeoPosition() { Longitude = geo.Value.Longitude, Latitude = geo.Value.Latitude };
            }
            return null;
        }
        /// <summary>
        /// 获取位置
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName">地址</param>
        /// <returns></returns>
        public async Task<MR.GeoPosition?> GeoPosAsync(string key, string geoName)
        {
            GeoPosition? geo = await Do(db => db.GeoPositionAsync(AddPreFixKey(key), geoName));
            if (geo.HasValue)
            {
                return new MR.GeoPosition() { Longitude = geo.Value.Longitude, Latitude = geo.Value.Latitude };
            }
            return null;
        }
        /// <summary>
        /// 查询距离给定位置的一定范围内的地址
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="radius">距离(m)</param>
        /// <param name="count">数量</param>
        /// <param name="asc">排序</param>
        public MR.GeoRadiusResult[] GeoRadius(string key, double longitude, double latitude, double radius, int count = -1, bool asc = true) => Do(db => db.GeoRadius(AddPreFixKey(key), longitude, latitude, radius, GeoUnit.Meters, count, asc ? Order.Ascending : Order.Descending));
        /// <summary>
        /// 查询指定位置一定范围内的地址
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName">位置</param>
        /// <param name="radius">距离</param>
        /// <param name="count">数量</param>
        /// <param name="asc">排序</param>
        /// <returns></returns>
        public MR.GeoRadiusResult[] GeoRadius(string key, string geoName, double radius, int count = -1, bool asc = true) => Do(db => db.GeoRadius(AddPreFixKey(key), geoName, radius, GeoUnit.Meters, count, asc ? Order.Ascending : Order.Descending));
        /// <summary>
        /// 查询距离给定位置的一定范围内的地址
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="radius">距离(m)</param>
        /// <param name="count">数量</param>
        /// <param name="asc">排序</param>
        public Task<MR.GeoRadiusResult[]> GeoRadiusAsync(string key, double longitude, double latitude, double radius, int count = -1, bool asc = true) => Do(db => db.GeoRadiusAsync(AddPreFixKey(key), longitude, latitude, radius, GeoUnit.Meters, count, asc ? Order.Ascending : Order.Descending));
        /// <summary>
        /// 查询指定位置一定范围内的地址
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="geoName">位置</param>
        /// <param name="radius">距离</param>
        /// <param name="count">数量</param>
        /// <param name="asc">排序</param>
        /// <returns></returns>
        public Task<MR.GeoRadiusResult[]> GeoRadiusAsync(string key, string geoName, double radius, int count = -1, bool asc = true) => Do(db => db.GeoRadiusAsync(AddPreFixKey(key), geoName, radius, GeoUnit.Meters, count, asc ? Order.Ascending : Order.Descending));
    }
}
