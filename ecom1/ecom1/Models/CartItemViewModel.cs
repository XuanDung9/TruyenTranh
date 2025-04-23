using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecom1.Models
{
    public class CartItemViewModel
    {
        public string TenSP { get; set; }
        public string ProductId { get; set; }

        public string HinhAnh { get; set; }
        public double ChieuDai { get; set; }
        public double CanNang { get; set; }
        public int GiaTien { get; set; }
        public int SoLuong { get; set; }
    }
}