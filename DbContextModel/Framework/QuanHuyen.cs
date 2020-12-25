namespace DbContextModel.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuanHuyen")]
    public partial class QuanHuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuanHuyen()
        {
            ThongTinBDS = new HashSet<ThongTinBDS>();
        }

        [Key]
        [Display(Name = "Mã quận  /  huyện")]
        public int MaQuanHuyen { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên quận / huyện")]

        public string TenQuanHuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinBDS> ThongTinBDS { get; set; }
    }
}
