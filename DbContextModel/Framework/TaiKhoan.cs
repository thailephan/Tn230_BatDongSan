namespace DbContextModel.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            ThongTins = new HashSet<ThongTin>();
        }

        [Key]
        [StringLength(20)]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTin> ThongTins { get; set; }
    }
}
