using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DbContextModel.Framework
{
    public partial class DbContextWeb : DbContext
    {
        public DbContextWeb()
            : base("name=DbContext")
        {
        }

        public virtual DbSet<Anh> Anhs { get; set; }
        public virtual DbSet<Huong> Huongs { get; set; }
        public virtual DbSet<KhuDanCu> KhuDanCus { get; set; }
        public virtual DbSet<LoaiBDS> LoaiBDS { get; set; }
        public virtual DbSet<QuanHuyen> QuanHuyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThongTin> ThongTins { get; set; }
        public virtual DbSet<ThongTinBDS> ThongTinBDS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anh>()
                .HasMany(e => e.ThongTinBDS)
                .WithRequired(e => e.Anh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Huong>()
                .HasMany(e => e.ThongTinBDS)
                .WithRequired(e => e.Huong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhuDanCu>()
                .HasMany(e => e.ThongTinBDS)
                .WithRequired(e => e.KhuDanCu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiBDS>()
                .HasMany(e => e.ThongTinBDS)
                .WithRequired(e => e.LoaiBD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuanHuyen>()
                .HasMany(e => e.ThongTinBDS)
                .WithRequired(e => e.QuanHuyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTin>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTin>()
                .HasMany(e => e.ThongTinBDS)
                .WithRequired(e => e.ThongTin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinBDS>()
                .Property(e => e.SDTChuBan)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBDS>()
                .Property(e => e.Gia)
                .HasPrecision(19, 4);
        }
    }
}
