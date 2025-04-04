using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    [CollectionName("VideoBillboard")]
    public class VideoBillboard : IObject
    {
        public VideoBillboard()
        {
            DateWeek = DateTime.Now;
            VideoRating = 0;
            VideoImage = "noimage.jpg";
            BiggestSales = false;
            BiggestAirplay = false;
            HotShotDebut = false;

            GainsPerformance = false;
            StreamingGainer = false;
        }
        /// <summary>
        /// Chung tuần của video (ngày cuối cùng của tuần)
        /// </summary>
        [BsonRequired]
        [BsonElement("DateWeek")]
        public DateTime DateWeek { get; set; }

        /// <summary>
        /// Tên ca khúc Video
        /// </summary>
        [BsonRequired]
        [BsonElement("VideoName")]
        public string VideoName { get; set; }

        /// <summary>
        /// Ca sĩ
        /// </summary>
        [BsonRequired]
        [BsonElement("VideoAuthor")]
        public string VideoAuthor { get; set; }

        /// <summary>
        /// Ảnh album
        /// </summary>
        [BsonRequired]
        [BsonElement("VideoImage")]
        public string VideoImage { get; set; }

        /// <summary>
        /// Vị trí trên bảng xếp hạng
        /// </summary>
        [BsonElement("VideoRating")]
        public int VideoRating { get; set; }

        /// <summary>
        /// Tuần đầu tiên trên bảng xếp hạng
        /// </summary>
        [BsonElement("LastWeek")]
        public int LastWeek { get; set; }

        /// <summary>
        /// Giữ vị trí bao nhiêu tuần
        /// </summary>
        [BsonElement("PeakPosition")]
        public int PeakPosition { get; set; }

        [BsonElement("WKSonChart")]
        public int WKSonChart { get; set; }

        /// <summary>
        /// 0 là giữa nguyên vị trí trên bảng xếp hạng, 1 là tăng vị trí, -1 là giảm vị trí
        /// </summary>
        [BsonElement("VideoStatus")]
        public int VideoStatus { get; set; }

        /// <summary>
        /// Url để xem video online
        /// </summary>
        [BsonElement("VideoUrl")]
        public string VideoUrl { get; set; }

        /// <summary>
        /// Url để nghe ca khúc
        /// </summary>
        [BsonElement("VideoMp3")]
        public string VideoMp3 { get; set; }

        /// <summary>
        /// Video đạt danh số bán ra lớn nhất
        /// </summary>
        [BsonElement("BiggestSales")]
        public bool BiggestSales { get; set; }

        /// <summary>
        /// Video đạt số lượt nghe nhiều nhất trên Airplay
        /// </summary>
        [BsonElement("BiggestAirplay")]
        public bool BiggestAirplay { get; set; }

        /// <summary>
        /// Video tăng đột biến (nguyên văn là tăng hiệu suất)
        /// </summary>
        [BsonElement("GainsPerformance")]
        public bool GainsPerformance { get; set; }

        /// <summary>
        /// Highest ranking debut
        /// </summary>
        [BsonElement("HotShotDebut")]
        public bool HotShotDebut { get; set; }

        /// <summary>
        /// Biggest gain in streams
        /// </summary>
        [BsonElement("StreamingGainer")]
        public bool StreamingGainer { get; set; }

        /// <summary>
        /// Biggest gain in streams
        /// </summary>
        [BsonElement("Menu")]
        public string Menu { get; set; }
    }
}
