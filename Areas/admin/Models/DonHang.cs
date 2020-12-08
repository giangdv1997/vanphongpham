namespace Nhom1_VanPhongPham.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        [DisplayName("Mã đơn hàng")]
        public int MaDonHang { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime NgayTao { get; set; }

        [DisplayName("Tổng tiền")]
        public int TongTien { get; set; }

        [DisplayName("Mã tài khoản")]
        public int MaTaiKhoan { get; set; }
    }
}
