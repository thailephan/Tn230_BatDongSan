namespace DbContextModel.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinBDS")]
    public partial class ThongTinBDS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinBDS()
        {
            Anhs = new HashSet<Anh>();
        }
        [Key]
        [Display(Name = "Mã tin")]
        public int MaTin { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime NgayTao { get; set; }

        [Display(Name = "Chiều dài")]
        public double ChieuDai { get; set; }

        [Display(Name = "Chiều rộng")]
        public double ChieuRong { get; set; }

        [StringLength(1000)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "SĐT chủ bán")]
        public string SDTChuBan { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Giá (triệu đồng)")]
        public decimal Gia { get; set; }
        
        [Display(Name = "Mã hướng")]
        public int MaHuong { get; set; }

        [Display(Name = "Mã người dùng")]
        public int MaUser { get; set; }

        [Display(Name = "Mã loại")]
        public int MaLoai { get; set; }

        [Display(Name = "Mã quận huyện")]
        public int MaQuanHuyen { get; set; }

        [Display(Name = "Mã khu dân cư")]
        public int MaKhuDanCu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anh> Anhs { get; set; }

        public virtual Huong Huong { get; set; }

        public virtual KhuDanCu KhuDanCu { get; set; }

        public virtual LoaiBDS LoaiBD { get; set; }

        public virtual QuanHuyen QuanHuyen { get; set; }

        public virtual ThongTin ThongTin { get; set; }
    }
}
