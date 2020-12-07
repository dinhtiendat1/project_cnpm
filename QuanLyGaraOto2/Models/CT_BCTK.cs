namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_BCTK
    {
        [Key]
        public int MaCT_BCTK { get; set; }

        [StringLength(100)]
        public string TenLinhKien { get; set; }

        public int? TonDau { get; set; }

        public int? TonCuoi { get; set; }

        public int MaBCTK { get; set; }

        public virtual BAOCAOTONKHO BAOCAOTONKHO { get; set; }
    }
}
