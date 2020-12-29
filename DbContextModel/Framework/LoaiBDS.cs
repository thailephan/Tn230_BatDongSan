﻿namespace DbContextModel.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiBDS")]
    public partial class LoaiBDS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiBDS()
        {
            ThongTinBDS = new HashSet<ThongTinBDS>();
        }

        [Key]
        [Display(Name = "Mã loại")]
        public int MaLoai { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên loại")]
        public string TenLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinBDS> ThongTinBDS { get; set; }
    }
}
