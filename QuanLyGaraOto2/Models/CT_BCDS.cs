namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_BCDS
    {
        [Key]
        public int MaCT_BCDS { get; set; }

        [StringLength(30)]
        [DisplayName("Hiệu xe")]
        public string HieuXe { get; set; }

        [DisplayName("Số lượt sửa chữa")]
        public int? SoLuotSua { get; set; }

        [DisplayName("Thành tiền")]
        public double? ThanhTien { get; set; }

        [DisplayName("Tỉ lệ")]
        public double? TiLe { get; set; }

        public int MaBCDS { get; set; }

        public virtual BAOCAODOANHSO BAOCAODOANHSO { get; set; }
    }
}
