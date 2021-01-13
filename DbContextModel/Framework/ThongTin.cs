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

        [Required(ErrorMessage = "Họ tên không được trống")]
        [Display(Name = "Họ và tên người dùng")]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được trống")]
        [StringLength(200, ErrorMessage = "Địa chỉ không được dài quá 200 ký tự")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(10, ErrorMessage = "Số điện thoại không quá 10 ký tự")]
        [Display(Name = "Số điện thoại"), DataType(DataType.PhoneNumber)]
        public string SDT { get; set; }
        
        [Display(Name = "Năm sinh"), Required(ErrorMessage = "Năm sinh không được để trống")]
        [Range(1900, 9999, ErrorMessage = "Năm sinh phải lớn hơn 1900")]
        public int NamSinh { get; set; }

        [Required(ErrorMessage = "Nhập giới tính của bạn")]
        [Display(Name = "Giới tính")]
        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(20)]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinBDS> ThongTinBDS { get; set; }
    }
}
