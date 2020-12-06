namespace QuanLyGaraOto2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyGaraOto2Context : DbContext
    {
        public QuanLyGaraOto2Context()
            : base("name=QuanLyGaraOto2Context")
        {
        }

        public virtual DbSet<BAOCAODOANHSO> BAOCAODOANHSOes { get; set; }
        public virtual DbSet<BAOCAOTONKHO> BAOCAOTONKHOes { get; set; }
        public virtual DbSet<CT_BCDS> CT_BCDS { get; set; }
        public virtual DbSet<CT_BCTK> CT_BCTK { get; set; }
        public virtual DbSet<CT_PHIEUNHAPLK> CT_PHIEUNHAPLK { get; set; }
        public virtual DbSet<CT_PHIEUSUACHUA> CT_PHIEUSUACHUA { get; set; }
        public virtual DbSet<DICHVU_LINHKIEN> DICHVU_LINHKIEN { get; set; }
        public virtual DbSet<HIEUXE> HIEUXEs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<PHIEUNHAPLINHKIEN> PHIEUNHAPLINHKIENs { get; set; }
        public virtual DbSet<PHIEUSUACHUA> PHIEUSUACHUAs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<XE> XEs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BAOCAODOANHSO>()
                .HasMany(e => e.CT_BCDS)
                .WithRequired(e => e.BAOCAODOANHSO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BAOCAOTONKHO>()
                .HasMany(e => e.CT_BCTK)
                .WithRequired(e => e.BAOCAOTONKHO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CT_BCDS>()
                .Property(e => e.HieuXe)
                .IsUnicode(false);

            modelBuilder.Entity<DICHVU_LINHKIEN>()
                .HasMany(e => e.CT_PHIEUNHAPLK)
                .WithRequired(e => e.DICHVU_LINHKIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DICHVU_LINHKIEN>()
                .HasMany(e => e.CT_PHIEUSUACHUA)
                .WithRequired(e => e.DICHVU_LINHKIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HIEUXE>()
                .Property(e => e.TenHX)
                .IsUnicode(false);

            modelBuilder.Entity<HIEUXE>()
                .HasMany(e => e.XEs)
                .WithRequired(e => e.HIEUXE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.PHIEUNHAPLINHKIENs)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUNHAPLINHKIEN>()
                .HasMany(e => e.CT_PHIEUNHAPLK)
                .WithRequired(e => e.PHIEUNHAPLINHKIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUSUACHUA>()
                .Property(e => e.BienSo)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUSUACHUA>()
                .HasMany(e => e.CT_PHIEUSUACHUA)
                .WithRequired(e => e.PHIEUSUACHUA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.QUYENs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XE>()
                .Property(e => e.BienSo)
                .IsUnicode(false);

            modelBuilder.Entity<XE>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<XE>()
                .HasMany(e => e.PHIEUSUACHUAs)
                .WithRequired(e => e.XE)
                .WillCascadeOnDelete(false);
        }
    }
}
