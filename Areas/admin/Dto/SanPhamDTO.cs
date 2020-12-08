using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom1_VanPhongPham.Areas.admin.Dto
{
    public class SanPhamDTO
    {
        public int MaSanPham { get; set; }

        public string TenSanPham { get; set; }

        public int TongSoLuong { get; set; }

        public string XuatXu { get; set; }

        public string QuyCach { get; set; }

        public string DonViTinh { get; set; }

        public int MaDanhMuc { get; set; }

        public string AnhSanPham { get; set; }

        public string TenDanhMuc { get; set; }
    }
}