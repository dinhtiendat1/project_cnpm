namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUSUACHUA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã phiếu sửa chữa")]
        public int MaPhieuSC { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã DV/LK")]
        public int MaDV_LK { get; set; }

        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }
        [DisplayName("Thành tiền")]
        public double ThanhTien { get; set; }

        public virtual DICHVU_LINHKIEN DICHVU_LINHKIEN { get; set; }

        public virtual PHIEUSUACHUA PHIEUSUACHUA { get; set; }
    }
}
