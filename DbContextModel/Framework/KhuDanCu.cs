namespace DbContextModel.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuDanCu")]
    public partial class KhuDanCu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhuDanCu()
        {
            ThongTinBDS = new HashSet<ThongTinBDS>();
        }

        [Key]
        [Display(Name = "Mã khu dân cư")]
        public int MaKhuDanCu { get; set; }

        [Required(ErrorMessage = "Tên khu dân cư không được trống")]
        [Display(Name = "Tên khu dân cư")]
        [StringLength(2000)]
        public string TenKhuDanCu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinBDS> ThongTinBDS { get; set; }
    }
}
