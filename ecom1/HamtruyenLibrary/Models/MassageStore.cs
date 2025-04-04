using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    
    public class phuongthuclienlac
    {
        public string tenphuongthuc { get; set; }
        public string giatri { get; set; }
    }

    [CollectionName("thanhpho")]
    public class thanhpho:IObject
    {
        public string tenthanhpho { get; set; }
        public int soquan { get; set; }

    }

    [CollectionName("quanmassage")]
    public class quanmassage : IObject
    {
        public quanmassage()
        {
            lienhe = new List<phuongthuclienlac>();
            anhquan = new List<string>();
            trangthai = -1;
            longtitude = 0;
            latitude = 0;
        }
        public string tenquan { get; set; }
        public string tukhoasearch { get; set; }
        public float chamdiem { get; set; }
        public string anhdaidien { get; set; }
        public List<string> anhquan { get; set; }
        public string diachi { get; set; }
        public decimal longtitude { get; set; }
        public decimal latitude { get; set; }
        public string giomocua { get; set; }
        public string mota { get; set; }
        public string thanhphoid { get; set; }
        public string thanhpho { get; set; }
        public List<phuongthuclienlac> lienhe { get; set; }

        /// <summary>
        /// -1 là chưa hoạt động, 0 là đang hoạt động, 1 là quán uy tín
        /// </summary>
        public int trangthai { get; set; }
    }

    [CollectionName("ktvmassage")]
    public class ktvmassage : IObject
    {
        public ktvmassage()
        {
            hinhanh = new List<string>();
            namsinh = DateTime.Now.Year;
            gia = 0;
            giakm = 0;
            status = 0;
        }
        public string tenktv { get; set; }
        public List<string> hinhanh { get; set; }
        public int numberlike { get; set; }
        public string gioithieu { get; set; }

        /// <summary>
        /// 0 là còn hàng, 1 là hết hàng
        /// </summary>
        public int status { get; set; }
        public int namsinh { get; set; }
        public string dichvu { get; set; }

        public int gia { get; set; }
        /// <summary>
        /// giá khuyến mãi nếu có
        /// </summary>
        public int giakm { get; set; }

    }

    public class tintuc : IObject
    {

    }

    public class quangcao:IObject
    {
        
    }

    [CollectionName("comment")]
    public class comment:IObject
    {
        public comment()
        {
            numberlike = 0;
            attachment = "";
            childcomments = new List<comment>();
        }
        public string username { get; set; }
        public string userid { get; set; }
        public string avatar { get; set; }
        public string commentcontent { get; set; }
        public int numberlike { get; set; }
        public double thoigiancomment { get; set; }
        public int numberstar { get; set; }

        public string attachment { get; set; }
        public string topicname { get; set; }
        public string topicid { get; set; }

        /// <summary>
        /// 0 là comment ktv, 1 là comment quán, 2 là comment review
        /// </summary>
        public int commenttype { get; set; }

        public List<comment> childcomments { get; set; }

    }


    [CollectionName("thanhvien")]
    public class thanhvien : IObject
    {
        public string email { get; set; }
        public string passage { get; set; }
        public string tenhienthi { get; set; }
        public string sodienthoai { get; set; }
        public string avatar { get; set; }
        public string ngaysinh { get; set; }
        public int gioitinh { get; set; }
        public string nghenghiep { get; set; }

        /// <summary>
        /// 1 là thành viên thường 
        /// </summary>
        public int usertype { get; set; }

    }


}
