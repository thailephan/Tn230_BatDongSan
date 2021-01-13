namespace DbContextModel.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

    public partial class DbContextWeb : DbContext
    {
        public DbContextWeb()
            : base("name=DbContextWeb")
        {
        }

        public virtual DbSet<Anh> Anhs { get; set; }
        public virtual DbSet<Huong> Huongs { get; set; }
        public virtual DbSet<KhuDanCu> KhuDanCus { get; set; }
        public virtual DbSet<LoaiBDS> LoaiBDS { get; set; }
        public virtual DbSet<QuanHuyen> QuanHuyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThongTin> ThongTinsBDS { get; set; }
        public virtual DbSet<ThongTinBDS> ThongTinBDS { get; set; }

        public List<TaiKhoan> LoginByUsernamePassword (string UserName, string password)
        {
            return this.TaiKhoans.Where(m => m.UserName == UserName && m.Password == password).Select( m => m).ToList();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
