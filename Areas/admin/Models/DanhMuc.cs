namespace Nhom1_VanPhongPham.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        [Key]
        [DisplayName("Mã danh mục")]
        public int MaDanhMuc { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên danh mục")]
        public string TenDanhMuc { get; set; }

        [DisplayName("Mã danh mục cha")]
        public int? MaCha { get; set; }
    }
}
