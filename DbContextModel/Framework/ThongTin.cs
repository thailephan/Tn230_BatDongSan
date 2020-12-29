namespace DbContextModel.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTin")]
    public partial class ThongTin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTin()
        {
            ThongTinBDS = new HashSet<ThongTinBDS>();
        }

        [Key]
        [Display(Name = "Mã người dùng")]
        public int MaUser { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Họ tên người dùng")]
        public string HoTen { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Địa chỉ người dùng")]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [Display(Name = "Năm sinh")]
        public int NamSinh { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [StringLength(20)]
        [Display(Name = "Tên người dùng")]
        public string UserName { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinBDS> ThongTinBDS { get; set; }
    }
}
