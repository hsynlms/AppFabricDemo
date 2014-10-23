using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFabricDemo
{
    public interface IAppFabric
    {
        object GetData(string strKey);
        IEnumerable<KeyValuePair<string, object>> GetDataByTag(string strTag, string strRegionName);
        object GetObjects(string strRegionName);
        void SetData(string strKey, object objValue);
        void PutData(string strKey, object objValue);
        void RemoveEntry(string strKey);
        void ClearRegions();
        void ClearRegion(string strRegionName);
        void RemoveRegion(string strRegionName);
        void RemoveRegions();
        void CreateRegion(string strRegionName);
        
    }
}
