namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUSUACHUA")]
    public partial class PHIEUSUACHUA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUSUACHUA()
        {
            CT_PHIEUSUACHUA = new HashSet<CT_PHIEUSUACHUA>();
        }

        [Key]
        public int MaPhieuSC { get; set; }

        [DisplayName("Ngày sửa chữa")]
        public DateTime NgaySuaChua { get; set; }

        [DisplayName("Ngày thu tiền")]
        public DateTime? NgayThuTien { get; set; }

        [DisplayName("Số tiền thu")]
        public double SoTienThu { get; set; }

        [DisplayName("Ngày tiếp nhận xe")]
        public DateTime NgayTiepNhanXe { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Biển số")]
        public string BienSo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUSUACHUA> CT_PHIEUSUACHUA { get; set; }

        public virtual XE XE { get; set; }
    }
}
