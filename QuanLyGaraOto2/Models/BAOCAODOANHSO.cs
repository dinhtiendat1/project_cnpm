namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAOCAODOANHSO")]
    public partial class BAOCAODOANHSO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BAOCAODOANHSO()
        {
            CT_BCDS = new HashSet<CT_BCDS>();
        }

        [Key]
        public int MaBCDS { get; set; }

        public int Thang { get; set; }

        public double TongDoanhSo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_BCDS> CT_BCDS { get; set; }
    }
}
