using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Battery")]
    public class Battery:IObject
    {
        public Battery()
        {
            string CongNghe = "Super Fast Charging 2.0";
            string LoaiPin = "Li-on";
            int DungLuong = 5000;
        }
    }
}
