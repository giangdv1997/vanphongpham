using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nhom1_VanPhongPham.Models;

namespace Nhom1_VanPhongPham.Models
{
    public class ProductByCat
    {
        public DanhMuc cat { get; set; }
        public List<SanPham> products { get; set; }
    }
}