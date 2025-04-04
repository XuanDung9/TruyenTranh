using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("DeviceApp")]
    public class DeviceApp : IObject
    {
        public DeviceApp()
        {

        }
        public string UserID { get; set; }
        public string UserName { get; set; }

        public string Tags { get; set; }

        public string TokenID { get; set; }
    }
}
