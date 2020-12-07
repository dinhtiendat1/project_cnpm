namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_BCTK
    {
        [Key]
        public int MaCT_BCTK { get; set; }

        [StringLength(100)]
        [DisplayName("Tên linh kiện")]
        public string TenLinhKien { get; set; }

        [DisplayName("Tồn đầu")]
        public int? TonDau { get; set; }

        [DisplayName("Tồn cuối")]
        public int? TonCuoi { get; set; }

        public int MaBCTK { get; set; }

        public virtual BAOCAOTONKHO BAOCAOTONKHO { get; set; }
    }
}
