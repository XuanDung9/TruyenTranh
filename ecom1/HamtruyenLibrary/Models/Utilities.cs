using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Utilities")]
    public class Utilities:IObject
    {
        public Utilities()
        {
            string TinhNang = "Thực hiện tác vụ liên ứng dụng bằng lời nói (Seamless Actions across Apps)";
            string BaoMat = "Vân tay dưới màn hình";
        }

        [BsonElement("TinhNang")]
        public string TinhNang
        {
            get;
            set;
        }
        [BsonElement("BaoMat")]
        public string BaoMat
        {
            get;
            set;
        }
    }
     

}
