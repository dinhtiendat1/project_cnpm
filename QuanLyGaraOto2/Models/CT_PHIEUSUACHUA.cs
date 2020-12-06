namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUSUACHUA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPhieuSC { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDV_LK { get; set; }

        public int? SoLuong { get; set; }

        public double ThanhTien { get; set; }

        public virtual DICHVU_LINHKIEN DICHVU_LINHKIEN { get; set; }

        public virtual PHIEUSUACHUA PHIEUSUACHUA { get; set; }
    }
}
