namespace Nhom1_VanPhongPham.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPhamMauSac")]
    public partial class SanPhamMauSac
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSanPham { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaMau { get; set; }

        public int SoLuongCon { get; set; }
    }
}
