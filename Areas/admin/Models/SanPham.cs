namespace Nhom1_VanPhongPham.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        [DisplayName("Mã sản phẩm")]
        public int MaSanPham { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên sản phẩm")]
        public string TenSanPham { get; set; }

        [DisplayName("Tổng số lượng")]
        public int TongSoLuong { get; set; }

        [StringLength(50)]
        [DisplayName("Xuất xứ")]
        public string XuatXu { get; set; }

        [StringLength(50)]
        [DisplayName("Quy cách")]
        public string QuyCach { get; set; }

        [StringLength(50)]
        [DisplayName("Đơn vị tính")]
        public string DonViTinh { get; set; }

        [DisplayName("Mã danh mục")]
        public int MaDanhMuc { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Ảnh sản phẩm")]
        public string AnhSanPham { get; set; }
    }
}
