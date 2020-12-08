namespace Nhom1_VanPhongPham.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            SanPhamMauSacs = new HashSet<SanPhamMauSac>();
        }

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

        [Column(TypeName = "numeric")]
        public decimal? GiaSanPham { get; set; }

        [StringLength(1000)]
        public string MoTa { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPhamMauSac> SanPhamMauSacs { get; set; }
    }
}
