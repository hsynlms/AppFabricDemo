using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationServer.Caching;

namespace AppFabricDemo.Classes
{
    public class AppFabric : IAppFabric
    {
        private DataCacheFactoryConfiguration conf = null;
        private DataCache cache = null;

        //Overloaded constructors have been implemented below.
        public AppFabric(List<DataCacheServerEndpoint> cacheServers, string strCacheName = "default", int channelOpenTimeoutSeconds = 20)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strCacheName))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    this.conf = new DataCacheFactoryConfiguration();
                    this.conf.Servers = cacheServers;
                    this.conf.ChannelOpenTimeout = TimeSpan.FromSeconds(channelOpenTimeoutSeconds);
                    this.conf.LocalCacheProperties = new DataCacheLocalCacheProperties();

                    DataCacheFactory factory = new DataCacheFactory(this.conf);
                    this.cache = factory.GetCache(strCacheName);
                }
            }
            catch
            {
                throw;
            }
        }
        public AppFabric(DataCacheServerEndpoint cacheServer, string strCacheName = "default", int channelOpenTimeoutSeconds = 20)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strCacheName))
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    this.conf = new DataCacheFactoryConfiguration();
                    this.conf.Servers = new[] { cacheServer };
                    this.conf.ChannelOpenTimeout = TimeSpan.FromSeconds(channelOpenTimeoutSeconds);
                    this.conf.LocalCacheProperties = new DataCacheLocalCacheProperties();

                    DataCacheFactory factory = new DataCacheFactory(this.conf);
                    this.cache = factory.GetCache(strCacheName);
                }
            }
            catch
            {
                throw;
            }
        }
        public AppFabric(string strHost, int intPort, string strCacheName = "default", int channelOpenTimeoutSeconds = 20)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strHost) || string.IsNullOrWhiteSpace(strCacheName))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    this.conf = new DataCacheFactoryConfiguration();
                    this.conf.Servers = new[] { new DataCacheServerEndpoint(strHost, intPort) };
                    this.conf.ChannelOpenTimeout = TimeSpan.FromSeconds(channelOpenTimeoutSeconds);
                    this.conf.LocalCacheProperties = new DataCacheLocalCacheProperties();

                    DataCacheFactory factory = new DataCacheFactory(this.conf);
                    this.cache = factory.GetCache(strCacheName);
                }
            }
            catch
            {
                throw;
            }
        }

        //GET data methods have been implemented below.
        public object GetData(string strKey)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey))
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    return cache.Get(strKey);
                }
            }
            catch
            {
                throw;
            }
        }
        public object GetData(string strKey, string strRegion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || string.IsNullOrWhiteSpace(strRegion))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    return cache.Get(strKey, strRegion);
                }
            }
            catch
            {
                throw;
            }
        }
        public List<object> GetData(List<string> strKeys)
        {
            try
            {
                if (strKeys.Count <= 0)
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    List<object> collect = new List<object>();

                    foreach (var key in strKeys)
                    {
                        if (cache.Get(key) != null)
                        {
                            collect.Add(cache.Get(key));
                        }
                        else
                        {
                            throw new Exception("No data found by this key: " + key);
                        }
                    }

                    return collect;
                }
            }
            catch
            {
                throw;
            }
        }

        //GET data by tag has been implemented below.
        public IEnumerable<KeyValuePair<string, object>> GetDataByTag(string strTag, string strRegionName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strTag) || string.IsNullOrWhiteSpace(strRegionName))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    return cache.GetObjectsByTag(new DataCacheTag(strTag), strRegionName);
                }
            }
            catch
            {
                throw;
            }
        }

        //GET objects (in region or in region by tags) methods have been implemented below.
        public object GetObjects(string strRegionName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strRegionName))
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    return cache.GetObjectsInRegion(strRegionName);
                }
            }
            catch
            {
                throw;
            }
        }
        public object GetObjects(string strTag, string strRegionName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strTag) || string.IsNullOrWhiteSpace(strRegionName))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    return cache.GetObjectsByTag(new DataCacheTag(strTag), strRegionName);
                }
            }
            catch
            {
                throw;
            }
        }

        //SET data methods have been implemented below.
        public void SetData(string strKey, object objValue)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || objValue == null)
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey) == null)
                    {
                        cache.Add(strKey, objValue);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void SetData(string strKey, object objValue, string strRegion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || objValue == null || string.IsNullOrWhiteSpace(strRegion))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey, strRegion) == null)
                    {
                        cache.Add(strKey, objValue, strRegion);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void SetData(string strKey, object objValue, TimeSpan timeOut)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || objValue == null || timeOut == null)
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey) == null)
                    {
                        cache.Add(strKey, objValue, timeOut);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void SetData(string strKey, object objValue, TimeSpan timeOut, string strRegion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || objValue == null || timeOut == null || string.IsNullOrWhiteSpace(strRegion))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey, strRegion) == null)
                    {
                        cache.Add(strKey, objValue, timeOut, strRegion);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void SetData(Dictionary<string, object> strData)
        {
            try
            {
                if (strData.Count() <= 0)
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    foreach (var key in strData)
                    {
                        if (cache.Get(key.Key) == null)
                        {
                            cache.Add(key.Key, key.Value);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void SetData(string strKey, object objValue, List<DataCacheTag> DataTags, string strRegion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || objValue == null || DataTags == null || string.IsNullOrWhiteSpace(strRegion))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey, strRegion) == null)
                    {
                        cache.Add(strKey, objValue, DataTags, strRegion);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        //PUT data methods have been implemented below.
        public void PutData(string strKey, object objValue)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || objValue == null)
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey) != null)
                    {
                        cache.Put(strKey, objValue);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void PutData(string strKey, object objValue, string strRegion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || objValue == null || string.IsNullOrWhiteSpace(strRegion))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey, strRegion) != null)
                    {
                        cache.Put(strKey, objValue, strRegion);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void PutData(string strKey, object objValue, TimeSpan timeOut)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || objValue == null || timeOut == null)
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey) != null)
                    {
                        cache.Put(strKey, objValue, timeOut);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void PutData(string strKey, object objValue, TimeSpan timeOut, string strRegion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || objValue == null || timeOut == null || string.IsNullOrWhiteSpace(strRegion))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey, strRegion) != null)
                    {
                        cache.Put(strKey, objValue, timeOut, strRegion);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void PutData(Dictionary<string, object> strData)
        {
            try
            {
                if (strData.Count() <= 0)
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    foreach (var key in strData)
                    {
                        if (cache.Get(key.Key) != null)
                        {
                            cache.Put(key.Key, key.Value);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void PutData(string strKey, object objValue, List<DataCacheTag> DataTags, string strRegion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || objValue == null || DataTags == null || string.IsNullOrWhiteSpace(strRegion))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey, strRegion) != null)
                    {
                        cache.Put(strKey, objValue, DataTags, strRegion);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        //REMOVE data methods have been implemented below.
        public void RemoveEntry(string strKey)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey))
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey) != null)
                    {
                        cache.Remove(strKey);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void RemoveEntry(string strKey, string strRegion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strKey) || string.IsNullOrWhiteSpace(strRegion))
                {
                    throw new Exception("Parameters are not valid or incorrect.");
                }
                else
                {
                    if (cache.Get(strKey, strRegion) != null)
                    {
                        cache.Remove(strKey, strRegion);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void RemoveEntry(List<string> strKeys)
        {
            try
            {
                if (strKeys.Count <= 0)
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    foreach (var key in strKeys)
                    {
                        if (cache.Get(key) != null)
                        {
                            cache.Remove(key);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        //Clear all data from the each regions.
        public void ClearRegions()
        {
            try
            {
                foreach (var region in cache.GetSystemRegions())
                {
                    cache.ClearRegion(region);
                }
            }
            catch
            {
                throw;
            }
        }

        //Clear all data from the specified region.
        public void ClearRegion(string strRegionName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strRegionName))
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    this.cache.ClearRegion(strRegionName);
                }
            }
            catch
            {
                throw;
            }
        }

        //Remove the specified region.
        public void RemoveRegion(string strRegionName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strRegionName))
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    this.cache.RemoveRegion(strRegionName);
                }
            }
            catch
            {
                throw;
            }
        }

        //Remove all regions.
        public void RemoveRegions()
        {
            try
            {
                foreach (var region in this.cache.GetSystemRegions())
                {
                    this.cache.RemoveRegion(region);
                }
            }
            catch
            {
                throw;
            }
        }

        //Create a new region(s).
        public void CreateRegion(string strRegionName)
        {
            try
            {
                if (string.IsNullOrEmpty(strRegionName))
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    this.cache.CreateRegion(strRegionName);
                }
            }
            catch
            {
                throw;
            }
        }
        public void CreateRegion(List<string> regionNames)
        {
            try
            {
                if (regionNames.Count <= 0)
                {
                    throw new Exception("Parameter is not valid or incorrect.");
                }
                else
                {
                    foreach (var region in regionNames)
                    {
                        cache.CreateRegion(region);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}