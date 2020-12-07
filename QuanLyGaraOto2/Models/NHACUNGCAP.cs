namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACUNGCAP")]
    public partial class NHACUNGCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            PHIEUNHAPLINHKIENs = new HashSet<PHIEUNHAPLINHKIEN>();
        }

        [Key]
        [DisplayName("Nhà cung cấp")]
        public short MaNCC { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên nhà cung cấp")]
        public string TenNCC { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAPLINHKIEN> PHIEUNHAPLINHKIENs { get; set; }
    }
}
