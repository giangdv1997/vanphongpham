namespace Nhom1_VanPhongPham.Areas.admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MauSac")]
    public partial class MauSac
    {
        [Key]
        [StringLength(20)]
        public string MaMau { get; set; }
    }
}
