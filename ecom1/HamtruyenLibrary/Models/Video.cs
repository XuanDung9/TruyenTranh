using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("Video")]
    public class Video :IObject
    {
        public Video()
        {
            VideoName = "Video mới";
            UserUpload = "-1";
            Active = 0; IsHot = 0;
            PostDate = DateTime.Now;
            VideoView = 0;
        }
        [BsonElement("VideoName")]
        public string VideoName
        {
            get;
            set;
        }

        [BsonElement("VideoNameK")]
        public string VideoNameK
        {
            get;
            set;
        }

        [BsonElement("VideoPath")]
        public string VideoPath
        {
            get;
            set;
        }

        [BsonElement("VideoImage")]
        public string VideoImage
        {
            get;
            set;
        }

        [BsonElement("UserUpload")]
        public string UserUpload
        {
            get;
            set;
        }

        [BsonElement("VideoType")]
        public int VideoType
        {
            get;
            set;
        }

        [BsonElement("IsHot")]
        public int IsHot
        {
            get;
            set;
        }

        [BsonElement("Active")]
        public int Active
        {
            get;
            set;
        }


        [BsonElement("Menu")]
        public string Menu
        {
            get;
            set;
        }

        [BsonElement("PostDate")]
        [BsonDateTimeOptions(Representation = BsonType.Document)]
        public DateTime PostDate
        {
            get;
            set;
        }

        [BsonElement("VideoLength")]
        public string VideoLength
        {
            get;
            set;
        }

        [BsonElement("VideoView")]
        public int VideoView
        {
            get;
            set;
        }
    }
}
