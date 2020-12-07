namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Tên dịch vụ, linh kiện")]
        public string TenDV_LK { get; set; }

        [DisplayName("Đơn giá")]
        public double? DonGia { get; set; }

        [DisplayName("Số lượng tồn kho")]
        public int? SoLuongTonKho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAPLK> CT_PHIEUNHAPLK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUSUACHUA> CT_PHIEUSUACHUA { get; set; }
    }
}
