using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomClassTemplate.Objects
{
    internal class CacheItem
    {
        public object StoredObject { get; private set; }
        public DateTime Time { get; private set; }

        public CacheItem(object obj)
        {
            this.StoredObject = obj;
            this.Time = DateTime.UtcNow;
        }
    }
}
