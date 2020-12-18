namespace DbContextModel.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinBDS")]
    public partial class ThongTinBD
    {
        [Key]
        public int MaTin { get; set; }

        [Required]
        [StringLength(300)]
        public string TieuDe { get; set; }

        public DateTime NgayTao { get; set; }

        public double ChieuDai { get; set; }

        public double ChieuRong { get; set; }

        [StringLength(1000)]
        public string MoTa { get; set; }

        [Required]
        [StringLength(10)]
        public string SDTChuBan { get; set; }

        [Column(TypeName = "money")]
        public decimal Gia { get; set; }

        public int MaHuong { get; set; }

        public int MaAnh { get; set; }

        public int MaUser { get; set; }

        public int MaLoai { get; set; }

        public int MaQuanHuyen { get; set; }

        public int MaKhuDanCu { get; set; }

        public virtual Anh Anh { get; set; }

        public virtual Huong Huong { get; set; }

        public virtual KhuDanCu KhuDanCu { get; set; }

        public virtual LoaiBD LoaiBD { get; set; }

        public virtual QuanHuyen QuanHuyen { get; set; }

        public virtual ThongTin ThongTin { get; set; }
    }
}
