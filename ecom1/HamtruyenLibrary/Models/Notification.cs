using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    public class NotificationGCM
    {
        public string Title { get; set; }

        /// <summary>
        /// 0 là thông báo cập nhật truyện mới, 1 là thông báo update phiên bản, 2 là thông báo bình thường
        /// </summary>
        public int TypeAction { get; set; }

        public string Content { get; set; }

        public string Link { get; set; }
    }
}
