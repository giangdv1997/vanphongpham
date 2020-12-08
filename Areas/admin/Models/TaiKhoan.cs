namespace Nhom1_VanPhongPham.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [DisplayName("Mã tài khoản")]
        public int MaTaiKhoan { get; set; }

        [Required]
        [StringLength(250)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(60)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        [StringLength(10)]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        [DisplayName("Admin")]
        public bool VaiTro { get; set; }
    }
}
