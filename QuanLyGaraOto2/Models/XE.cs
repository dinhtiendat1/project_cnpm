namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XE")]
    public partial class XE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XE()
        {
            PHIEUSUACHUAs = new HashSet<PHIEUSUACHUA>();
        }

        [Key]
        [StringLength(20)]
        public string BienSo { get; set; }

        public short MaHX { get; set; }

        [Required]
        [StringLength(40)]
        public string TenChuXe { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(15)]
        public string DienThoai { get; set; }

        public double? TienNo { get; set; }

        public virtual HIEUXE HIEUXE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUSUACHUA> PHIEUSUACHUAs { get; set; }
    }
}
