namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUNHAPLK
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã dịch vụ/linh kiện")]
        public int MaDV_LK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã phiếu nhập linh kiện")]
        public int Ma_PhieuNLK { get; set; }
        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }

        public virtual PHIEUNHAPLINHKIEN PHIEUNHAPLINHKIEN { get; set; }

        public virtual DICHVU_LINHKIEN DICHVU_LINHKIEN { get; set; }
    }
}
