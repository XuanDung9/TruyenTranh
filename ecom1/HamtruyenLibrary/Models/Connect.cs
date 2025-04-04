using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Connect")]
    public class Connect: IObject
    {
        bool NFC = true;
        string MangDiDong = "5G";
        string SoESim = "2 nano SIM + Esim";
        bool Wifi = true;
        bool Bluetooth = true;

    }
}
