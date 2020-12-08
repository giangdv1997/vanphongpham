namespace Nhom1_VanPhongPham.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSanPham { get; set; }

        public int TongSoLuong { get; set; }

        [StringLength(50)]
        public string XuatXu { get; set; }

        [StringLength(50)]
        public string QuyCach { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        public int MaDanhMuc { get; set; }

        [Column(TypeName = "ntext")]
        public string AnhSanPham { get; set; }
    }
}
