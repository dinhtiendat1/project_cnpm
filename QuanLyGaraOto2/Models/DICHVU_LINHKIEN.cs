namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DICHVU_LINHKIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DICHVU_LINHKIEN()
        {
            CT_PHIEUNHAPLK = new HashSet<CT_PHIEUNHAPLK>();
            CT_PHIEUSUACHUA = new HashSet<CT_PHIEUSUACHUA>();
        }

        [Key]
        public int MaDV_LK { get; set; }

        [StringLength(50)]
        public string TenDV_LK { get; set; }

        public double? DonGia { get; set; }

        public int? SoLuongTonKho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAPLK> CT_PHIEUNHAPLK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUSUACHUA> CT_PHIEUSUACHUA { get; set; }
    }
}
