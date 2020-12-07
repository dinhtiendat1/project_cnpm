namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAPLINHKIEN")]
    public partial class PHIEUNHAPLINHKIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAPLINHKIEN()
        {
            CT_PHIEUNHAPLK = new HashSet<CT_PHIEUNHAPLK>();
        }

        [Key]
        [DisplayName("Mã phiếu nhập LK")]
        public int Ma_PhieuNLK { get; set; }
        [DisplayName("Ngày nhập")]
        public DateTime? NgayNhap { get; set; }
        [DisplayName("Mã nhà cung cấp")]
        public short MaNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAPLK> CT_PHIEUNHAPLK { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
