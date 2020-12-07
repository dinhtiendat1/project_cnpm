namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYEN")]
    public partial class QUYEN
    {
        [Key]
        public int MaQuyen { get; set; }

        [Required]
        [StringLength(30)]
        public string TenQuyen { get; set; }

        public int MaTK { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
