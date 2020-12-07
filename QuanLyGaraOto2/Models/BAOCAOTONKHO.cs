namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAOCAOTONKHO")]
    public partial class BAOCAOTONKHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BAOCAOTONKHO()
        {
            CT_BCTK = new HashSet<CT_BCTK>();
        }

        [Key]
        public int MaBCTK { get; set; }

        [DisplayName("Thaìng")]
        public int Thang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_BCTK> CT_BCTK { get; set; }
    }
}
