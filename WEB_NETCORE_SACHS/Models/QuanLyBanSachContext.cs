using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WEB_NETCORE_SACHS.Models
{
    public partial class QuanLyBanSachContext : DbContext
    {
        public QuanLyBanSachContext()
        {
        }
        
        public QuanLyBanSachContext(DbContextOptions<QuanLyBanSachContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TacGia> TacGia { get; set; }
        public virtual DbSet<ThamGia> ThamGia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server=ADMIN-20200518L\\SQLEXPRESS;Database=QuanLyBanSach;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.UserAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.UserAdmin)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PassAdmin)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenAdmin)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => new { e.MaDonHang, e.MaSach });

                entity.ToTable("ChiTietDonHang");

                entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Sach)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_Sach");
            });

            modelBuilder.Entity<ChuDe>(entity =>
            {
                entity.HasKey(e => e.MaChuDe);

                entity.ToTable("ChuDe");

                entity.Property(e => e.TenChuDe).HasMaxLength(50);
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => new { e.MaDonHang, e.MaKh });

                entity.ToTable("DonHang");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.Property(e => e.NgayGiao).HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TtgiaoHang)
                    .HasMaxLength(50)
                    .HasColumnName("TTGiaoHang");

                entity.Property(e => e.TtthanhToan)
                    .HasMaxLength(50)
                    .HasColumnName("TTThanhToan");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => new { e.MaKh, e.Email });

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MaKH");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(50);
            });

            modelBuilder.Entity<NhaXuatBan>(entity =>
            {
                entity.HasKey(e => e.MaNxb);

                entity.ToTable("NhaXuatBan");

                entity.Property(e => e.MaNxb).HasColumnName("MaNXB");

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenNxb)
                    .HasMaxLength(50)
                    .HasColumnName("TenNXB");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach);

                entity.ToTable("Sach");

                entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaNxb).HasColumnName("MaNXB");

                entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");

                entity.Property(e => e.TenSach).HasMaxLength(100);

                entity.HasOne(d => d.ChuDe)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.MaChuDe)
                    .HasConstraintName("FK_Sach_ChuDe");

                entity.HasOne(d => d.NhaXuatBan)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.MaNxb)
                    .HasConstraintName("FK_Sach_NhaXuatBan");
            });

            modelBuilder.Entity<TacGia>(entity =>
            {
                entity.HasKey(e => e.MaTacGia);

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.DienThoai).HasMaxLength(50);

                entity.Property(e => e.TenTacGia).HasMaxLength(50);
            });

            modelBuilder.Entity<ThamGia>(entity =>
            {
                entity.HasKey(e => new { e.MaSach, e.MaTacGia });

                entity.Property(e => e.VaiTro).HasMaxLength(50);

                entity.Property(e => e.ViTri).HasMaxLength(50);

                entity.HasOne(d => d.MaSachs)
                    .WithMany(p => p.ThamGia)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThamGia_Sach");

                entity.HasOne(d => d.MaTacGias)
                    .WithMany(p => p.ThamGia)
                    .HasForeignKey(d => d.MaTacGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThamGia_TacGia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
