namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_BCDS
    {
        [Key]
        public int MaCT_BCDS { get; set; }

        [StringLength(30)]
        public string HieuXe { get; set; }

        public int? SoLuotSua { get; set; }

        public double? ThanhTien { get; set; }

        public double? TiLe { get; set; }

        public int MaBCDS { get; set; }

        public virtual BAOCAODOANHSO BAOCAODOANHSO { get; set; }
    }
}
